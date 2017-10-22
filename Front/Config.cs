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
   
        List<StudentSubject> listSubj = new List<StudentSubject>();
        StudentSubject none;
        List<Times> listTimes = new List<Times>();
        List<DaysofTheWeek> daysList = new List<DaysofTheWeek>();
        Dictionary<string, DaysofTheWeek> dictionary;
        public Config()
        {
            InitializeComponent();
            ResetList();
           
            daysList = Requests.GetDays();
            dictionary =daysList.ToDictionary(x => x.nome, y=>y);
            ResetTimesList();
            //       DataGridViewComboBoxColumn coluna = dataGridView2.Columns[2] as DataGridViewComboBoxColumn;

            //          coluna.ValueType = typeof(DaysOfTheWeek);
            //            coluna.DataSource = colunas;

            //coluna.ValueType = typeof(DaysOfTheWeek);
            //coluna.Items.Add(new DaysOfTheWeek() { Id = 1,nome="eu" } );
            /// coluna.Display
            //configBindingSource.Add("new") ;
            //   configBindingSource.DataSource = colunas;

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
                    listSubj.Add(novo);
                    listBox1.DataSource = null;
                    listBox1.DataSource = listSubj;
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
        private void ResetTimesList()
        {
            listTimes = Requests.GetTimes();
            int rowCount = listTimes.Count;

            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow curr = new DataGridViewRow();
                dataGridView2.Rows.Add(listTimes[i].Start, listTimes[i].End, listTimes[i].day.nome);
            }

        }
        private void ResetList()
        {
            try
            {
                listSubj = Requests.GetSubject();
                listBox1.DataSource = null;
                listBox1.DataSource = listSubj;
                none = listSubj.FirstOrDefault(x => x.Subject == "none");
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
            catch(WebException h)
            {
                MessageBox.Show("Invalid operation!");
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

        private void submitBtn_Click(object sender, EventArgs e)
        { 
            try
            {
                List<Times> listToAdd = new List<Times>();
                Console.WriteLine(dataGridView2);
                int rowCout = dataGridView2.RowCount;

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    DataGridViewRow d = dataGridView2.Rows[i];
                    listToAdd.Add(new Times() { Start = d.Cells[0].Value.ToString(), End = d.Cells[1].Value.ToString(), day = dictionary[d.Cells[2].Value.ToString()],subject = none });
                }
                
                Console.WriteLine(listToAdd);
                Requests.PostTimes(listToAdd);
                MessageBox.Show("Nice!");
            }
            catch(NullReferenceException g)
            {
                MessageBox.Show("Fill everything!");
            }
         //   foreach(DataRowView drv in listBox1.Items)
          //  {
          //      Console.WriteLine(drv.Row[0].ToString());
          //  }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
