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


    }
}