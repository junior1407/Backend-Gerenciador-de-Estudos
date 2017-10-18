using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    class Login
    {

        public Login(string text1, string text2)
        {
            this.Username = text1;
            this.Password = text2;
        }

        public override string ToString()
        {
            return String.Format("username: {0}, password {1}", Username, Password);
        }

        public string Username { get; set; }
        public string Password { get; set; }


    }
}
