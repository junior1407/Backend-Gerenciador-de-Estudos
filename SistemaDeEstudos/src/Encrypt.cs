using SistemaDeEstudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SistemaDeEstudos.src
{
    public class Encrypt
    {
        public static string getRandomString()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }
        public static string encryptPassword(string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder Sbuilder = new StringBuilder();
            foreach (byte b in data)
            {
                Sbuilder.Append(b.ToString("x2"));
            }
           return Sbuilder.ToString();
           
        }

 
        public static User getUser(string token, Model2 db)
        {


            List<LoginToken> list = db.LoginTokens.ToList();
            LoginToken e = db.LoginTokens.FirstOrDefault(z => z.Token == token);
            // System.Diagnostics.Debug.WriteLine(e.IdUser + "\\" + e.Token + "\\" + token + "\\" + (e.Token == token) + "\\" + String.Equals(token, e.Token));
           DateTime now = DateTime.UtcNow;
            if (e == default(LoginToken) || (now > e.End ))
            {
                System.Diagnostics.Debug.WriteLine("Cai1");
                return default(User);
            }

            System.Diagnostics.Debug.WriteLine("Cai2");
            User x = e.Student;
            System.Diagnostics.Debug.WriteLine(x.Nickname+"\\"+x.Avatar);
            return e.Student;
        }

        public static bool isAuthorized(User u, int IdUser)
        {
            if (u == default(User))
            {
                return false;
            }
            if (IdUser == u.Id)
            {
                return true;
            }
            return false;
        }
        public static bool isAuthorized(string token, int IdUser, Model2 db)
        {
            
            User u = getUser(token,db); 

            if (u == default(User))
            {
                System.Diagnostics.Debug.WriteLine("entrou aqui");
                return false;
            }
            if (IdUser == u.Id)
            {
             //   System.Diagnostics.Debug.WriteLine("entrou aqui2");
                return true;
            }
            //System.Diagnostics.Debug.WriteLine("entrou aqui3");
            return false;
        }

    }
}