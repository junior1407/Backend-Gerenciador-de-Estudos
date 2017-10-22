using Front.Model;
using Front.Services;
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
    public partial class Dashboard : Form
    {

        List<StudentSubject> subjectsList = new List<StudentSubject>();
        public void setDataGridOptions()
        {
            BindingSource binding = new BindingSource(subjectsList, null);
            DataGridViewComboBoxColumn column  = dataGridView1.Columns[3] as DataGridViewComboBoxColumn;
            column.ValueType = typeof(StudentSubject);
            column.DataSource = null;
            column.DataSource = binding;
            column.DisplayMember = "Subject";
            column.ValueMember = "This";
            
        }

        public void setDataGridRows()
        {
            
           List<Times> times = Requests.GetTimes();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //  x.cl
            foreach (Times t in times)
            {

              
                dataGridView1.Rows.Add(t.day, t.Start, t.End, null);
                //dayoftheweek, string ,string, StudentSubject

                StudentSubject curr = subjectsList.FirstOrDefault(x => x.Subject == t.subject.Subject); 
                if (curr==default(StudentSubject))
                {
                    subjectsList.Add(t.subject);
                }
                else
                {
                    t.subject = curr;
                }

                /*if (!(subjectsList.Any(x => x.Subject == t.subject.Subject)))
                {
                    subjectsList.Add(t.subject);
                }*/

             /*   if (subjectsList.Contains(t.subject) == false)
                {
                        subjectsList.Add(t.subject);
                }*/
                setDataGridOptions();
                dataGridView1.Rows[0].Cells[3].Value = t.subject;
                //  dataGridView1.Rows[0].Cells[4].Value = t.subject;
                //DataGridViewRow curr = dataGridView1      .Clone() as DataGridViewRow;

                //  dataGridView1.Rows.RemoveAt(0);
                /*  curr.Cells[0].Value = null;
                  curr.Cells[1].Value = t.day;
                  curr.Cells[2].Value = t.Start;
                  curr.Cells[3].Value = t.End;
                  curr.Cells[4].Value = t.subject;
                  dataGridView1.Rows.Add(curr);*/
            }

           
        }

        public void addMissing()
        {
            List<StudentSubject> temp = Requests.GetSubject();
            foreach(StudentSubject x in temp)
            {
                if (subjectsList.Where(z=>z.Subject== x.Subject).Count()==0)
                {

                    subjectsList.Add(x);
                }
            }

        }
        public Dashboard()
        {
            InitializeComponent();


          //  Main.token = Requests.Login("1", "1");
       //     dataGridView1.RowTemplate = new DataGridViewRow
         //  subjectsList =Requests.GetSubject();
       //     setDataGridOptions();
            setDataGridRows();
            addMissing();
            setDataGridOptions();

         //   setDataGridOptions();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Times> listToAdd = new List<Times>();
                int rowCout = dataGridView1.RowCount;

                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    DataGridViewRow d = dataGridView1.Rows[i];
                 //   dayoftheweek, string ,string, StudentSubject
                    listToAdd.Add(new Times() {  day=  d.Cells[0].Value as DaysofTheWeek, Start= d.Cells[1].Value.ToString(), End= d.Cells[2].Value.ToString(), subject= d.Cells[3].Value as StudentSubject});
                }

                Console.WriteLine(listToAdd);
                Requests.PostTimes(listToAdd);
                MessageBox.Show("Nice!");
            }
            catch (NullReferenceException g)
            {
                MessageBox.Show("Fill everything!");
            }
        }
    }
}
