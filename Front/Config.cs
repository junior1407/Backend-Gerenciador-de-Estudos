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
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Front
{
    public partial class Config : Form
    {
   
        List<StudentSubject> list = new List<StudentSubject>();
        List<string> colunas = new List<string>();
        public Config()
        {
            InitializeComponent();
          //  StudentSubject s1 = new StudentSubject { Grade = 10, Subject = "Calculo1" };
           //    list.Add(s1);
            
           listBox1.DataSource = list;
            //   ResetList();
            colunas.Add("Segunda");
            colunas.Add("Terça");
            colunas.Add("Quarta");
            colunas.Add("Quinta");
            colunas.Add("Sexta");
            colunas.Add("Sábado");
            //configBindingSource.Add("new") ;
            configBindingSource.DataSource = colunas;
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  StudentSubject curr = list.ElementAt(listBox1.SelectedIndex);
           // currGrade.Text = curr.Grade.ToString();
            //currSubject.Text = curr.Subject;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((newGrade.Text == "") || (newSubject.Text == ""))
            {
                MessageBox.Show("Fill all fields");
            }
            else
            {
                StudentSubject novo = new StudentSubject
                {
                    Grade = Convert.ToInt32(newGrade.Text),
                    Subject = newSubject.Text
                };
                try
                {
                    Requests.AddSubject(novo);
                    list.Add(novo);
                    listBox1.DataSource = null;
                    listBox1.DataSource = list;
                    MessageBox.Show("Sucesso!");
                }
                catch (UnauthorizedAccessException f)
                {
                    try
                    {
                        Requests.RefreshToken();
                        button2_Click(sender, e);
                    }
                    catch(ApplicationException x)
                    {
                        MessageBox.Show("Shoot! Something Happenned");
                    }
                 //   passwordText1.Text = "";
                }
                catch (ApplicationException g)
                {
                    MessageBox.Show("The server is offline!");
                }



                //  list.Add(novo);
                //   listBox1.DataSource = null;
                //   listBox1.DataSource = list;
                ResetList(); 
                MessageBox.Show("Sucesso!");

            }
        }

        private void ResetList()
        {
            try
            {
                list = Requests.GetSubject();
                listBox1.DataSource = null;
                listBox1.DataSource = list;
            }
            catch (UnauthorizedAccessException f)
            {
                try
                {
                    Requests.RefreshToken();
                    ResetList();
                }
                catch (ApplicationException x)
                {
                    MessageBox.Show("Shoot! Something Happenned");
                }
            }
            catch (ApplicationException g)
            {
                MessageBox.Show("The server is offline!");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            StudentSubject selected = (StudentSubject) listBox1.SelectedItem;
            try { Requests.DeleteSubject(selected);
                ResetList();
            }
            catch (UnauthorizedAccessException f)
            {
                try
                {
                    Requests.RefreshToken();
                    deleteBtn_Click(null, null);
                }
                catch (ApplicationException x)
                {
                    MessageBox.Show("Shoot! Something Happenned");
                }
            }
            catch (ApplicationException g)
            {
                MessageBox.Show("The server is offline!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("oi");
        }

        private void configBindingSource_CurrentChanged(object sender, EventArgs e)
        {
           // configBindingSource.
        }
    }
}
