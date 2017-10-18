using Front.Model;
using Front.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Front
{
    public partial class Form1 : Form
    {
        TokenKey token;
        public Form1()
        {
            InitializeComponent();
        }

        private void logarBtn_Click(object sender, EventArgs e)
        {
            if ((usernameText1.Text == String.Empty)|| (passwordText1.Text==String.Empty))
            {
                MessageBox.Show("Fill the fields!");
            }
            else
            {
                try
                {
                    token= Requests.Login(usernameText1.Text, passwordText1.Text);
                    // Main novoform = new Main(token);

                    // novoform.Show();
                    //   this.Hide();


                    this.Close();
                    Thread t = new Thread(OpenMain);
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();

                }
                catch(UnauthorizedAccessException f)
                {
                   
                }
                catch(ApplicationException g)
                {
                    MessageBox.Show("The server is offline!");
                }

            }
            
           




        }

     
        private void registerBtn_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click_1(object sender, EventArgs e)
        {
            if ((usernameBox.Text != "") && (passwordBox.Text != "") && (nickname.Text != "") && (avatar.Text != "") && (idRedeSocial.Text != ""))
            {
                RegisterInformation regis = new RegisterInformation { Username = usernameBox.Text, Password = passwordBox.Text, Nickname = nickname.Text, Avatar = avatar.Text, idRedeSocial = idRedeSocial.Text };

                try
                {
                    Requests.Register(regis);
                    tabControl1.SelectedIndex = 0;
                }
                catch (ArgumentException d)
                {
                    MessageBox.Show("Something happenned...");
                }
                catch (ApplicationException d)
                {
                    MessageBox.Show("Server off");
                }
            }
        }

        private void OpenMain()
        {
            Application.Run(new Main(token));
        }
    }
    
}
