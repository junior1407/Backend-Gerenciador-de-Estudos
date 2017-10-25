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
        List<DataGridViewRow> listRows = new List<DataGridViewRow>();
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
            foreach (Times t in times)
            {
                dataGridView1.Rows.Add(t.day, t.Start, t.End, null);

                StudentSubject curr = subjectsList.FirstOrDefault(x => x.Subject == t.subject.Subject); 
                if (curr==default(StudentSubject))
                {
                    subjectsList.Add(t.subject);
                }
                else
                {
                    t.subject = curr;
                }
                setDataGridOptions();
                
                dataGridView1.Rows[0].Cells[3].Value = t.subject;
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
            setDataGridRows();
            addMissing();
            setDataGridOptions();
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

        private void getRows()
        {
            listRows.Clear();
            foreach (DataGridViewRow curr in dataGridView1.Rows)
            {
                listRows.Add(curr);
            }
        }
        private void fixSubjectsList()
        {
           StudentSubject none = subjectsList.FirstOrDefault(x => x.Subject == "none");
            int pos = subjectsList.IndexOf(none);
            subjectsList.Add(none);
            subjectsList.RemoveAt(pos);
        }
        private void generateBtn_Click(object sender, EventArgs e)
        {
            int i, j;
            getRows();
            fixSubjectsList();
            float sumInverses=0;
            int bestSubject = 0;
            for (i = 0; i < subjectsList.Count - 1; i++)
            {
                if (subjectsList[i].Grade > subjectsList[bestSubject].Grade)
                {
                    bestSubject = i;
                }
                if (subjectsList[i].Grade != 0)
                {
                    sumInverses += (float)1 / (float)subjectsList[i].Grade;
                }
                else
                {
                    sumInverses += (float)1 / (float)0.1;
                }
            }
            double k = listRows.Count / sumInverses;
            int currRow = 0;
           
           
            for(i=0; i< subjectsList.Count -1; i++)
            {
                int time_curr;
                if (subjectsList[i].Grade==0)
                {
                    time_curr =(int) Math.Round((k *10));//   k / 0,1
                }
                else
                {
                    time_curr = (int)Math.Round(k / subjectsList[i].Grade);
                }
                for (j=currRow; j<currRow+time_curr;j++)
                {
                    listRows[j].Cells[3].Value = subjectsList[i];
                }
                currRow = j;
            }
            if (listRows[listRows.Count-1].Cells[3].Value== null)
            {
                listRows[listRows.Count - 1].Cells[3].Value = subjectsList[bestSubject];
            }
        }
    }
}
