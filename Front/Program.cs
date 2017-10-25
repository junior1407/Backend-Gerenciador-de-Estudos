using Front.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    static class Program
    {
        public static string url = "http://gerenciadorestudos.azurewebsites.net/api/";
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                     Application.Run(new Form1());
            // Application.Run(new Config());
           // Application.Run(new Dashboard());
         //    Application.Run(new Main(Requests.Login("1","1")));
        }
    }
}
