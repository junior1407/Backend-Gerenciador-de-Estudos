using Front.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class MainScreen : Form
    {
        TokenKey token;
        public MainScreen(TokenKey key)
        {
            this.token = key;
            InitializeComponent();
            Form1 x = new Form1();
            x.TopLevel = false;
            x.AutoScroll = true;
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            panel1.Controls.Add(x);
            x.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboardTab_Click(object sender, EventArgs e)
        {

        }
    }
}
