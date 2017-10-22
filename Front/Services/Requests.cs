using Front.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Front.Services
{
    public class Requests
    {
        public static TokenKey Login(string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "Logins");
            request.ContentType = "application/json";
            Console.Write(request.RequestUri);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new Login(username, password));
                stream.Write(json);
            }
            TokenKey key;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string saida = reader.ReadToEnd();
                    key = new JavaScriptSerializer().Deserialize<TokenKey>(saida);
                }
                return key;
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
            return null;
        }
        public static void Register(RegisterInformation r)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "Users");
            request.ContentType = "application/json";
            Console.Write(request.RequestUri);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(r);
                stream.Write(json);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new ArgumentException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }

        }
        public static void RefreshToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "Logins/Refresh");
            request.ContentType = "application/json";
            Console.Write(request.RequestUri);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(Main.token);
                stream.Write(json);
            }
            TokenKey key;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string saida = reader.ReadToEnd();
                    key = new JavaScriptSerializer().Deserialize<TokenKey>(saida);
                }
                Main.token = key;
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
        }
        public static void AddSubject(StudentSubject s)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "StudentSubjects");
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Main.token.Token);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(s);
                stream.Write(json);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
               if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException();
                }
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
        }
        public static List<Times> GetTimes()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "Times");
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Main.token.Token);
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string saida = reader.ReadToEnd();
                    List<Times> lista = new JavaScriptSerializer().Deserialize<List<Times>>(saida);
                    return lista;
                }
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
            return null;
        }
        public static void PostTimes(List<Times> l)
        {
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "Times");
        //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53630/api/Times");
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Main.token.Token);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(l);
                stream.Write(json);
                Console.WriteLine(json);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusCode);
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
        }
        public static List<DaysofTheWeek> GetDays()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "DaysofTheWeeks");
            request.ContentType = "application/json";
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string saida = reader.ReadToEnd();
                    List<DaysofTheWeek> lista = new JavaScriptSerializer().Deserialize<List<DaysofTheWeek>>(saida);

                    return lista;

                }


            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
            return null;
        }
        public static List<StudentSubject> GetSubject()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "StudentSubjects");
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Main.token.Token);
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string saida = reader.ReadToEnd();
                    List<StudentSubject> lista = new JavaScriptSerializer().Deserialize<List<StudentSubject>>(saida);
                    return lista;
                }
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
            return null;
        }
        public static void DeleteSubject(StudentSubject s)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Program.url.ToString() + "StudentSubjects/Delete");
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Main.token.Token);
            request.Method = "POST";
            using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(s);
                stream.Write(json);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException();
                }
            }
            catch (WebException d)
            {
                HttpWebResponse response = d.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ApplicationException();
                }
            }
        }

    }
}
