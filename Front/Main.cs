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
    public partial class Main : Form
    {
        public static TokenKey token;
        public Main(Model.TokenKey key)
        {
            token = key;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count==1)
            {
                panel1.Controls.RemoveAt(0);
            }
                      Config x = new Config();
            x.TopLevel = false;
            x.AutoScroll = true;
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            panel1.Controls.Add(x);
            x.Show();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count == 1)
            {
                panel1.Controls.RemoveAt(0);
            }
            Dashboard x = new Dashboard();
            x.TopLevel = false;
            x.AutoScroll = true;
            x.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            x.Dock = DockStyle.Fill;
            panel1.Controls.Add(x);
            x.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
