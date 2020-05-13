using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call.TeacherFolder;
using Roll_Call.ClassFolder;

namespace Roll_Call.StudentFolder
{
    public partial class ViewAllStudents : Form
    {
        public ViewAllStudents()
        {
            InitializeComponent();
        }

        private void ViewAllStudents_Load(object sender, EventArgs e)
        {
            List<Student> StudentList = StudentDB.StudentLoad();

            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "Grade";
            dataGridView1.Columns[4].Name = "Class 1";
            dataGridView1.Columns[5].Name = "Class 2";
            dataGridView1.Columns[6].Name = "Class 3";
            dataGridView1.Columns[7].Name = "Class 4";
            dataGridView1.Columns[8].Name = "Class 5";
            dataGridView1.Columns[9].Name = "Class 6";
            dataGridView1.Columns[10].Name = "Class 7";
            dataGridView1.Columns[11].Name = "Class 8";

            foreach (Student student in StudentList)
            {
                int count = 0;
                List<string> SCL = new List<string>() { "", "", "", "", "", "", "", "" };
                foreach (int classid in student.ClassID)
                {
                    SCL[count] = CLR(classid);
                    count++;
                }

                string[] row = 
                    new string[] { student.StudentID.ToString(), student.FirstName, student.LastName, student.Grade.ToString(), SCL[0],
                    SCL[1], SCL[2], SCL[3], SCL[4], SCL[5], SCL[6], SCL[7]};
                dataGridView1.Rows.Add(row);
            }

        }

        private string CLR (int id)
        {
            string classString;

            Classes newClass = ClassesDB.ClassFind(id);
            classString = newClass.ClassID.ToString() + " " + newClass.ClassTitle + " " + newClass.ClassTrack;
            
            return classString;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblGrade.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClassesStudent newForm = new AddClassesStudent();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentForm newForm = new StudentForm();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Student> StudentList = StudentDB.StudentLoad();

            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "Grade";
            dataGridView1.Columns[4].Name = "Class 1";
            dataGridView1.Columns[5].Name = "Class 2";
            dataGridView1.Columns[6].Name = "Class 3";
            dataGridView1.Columns[7].Name = "Class 4";
            dataGridView1.Columns[8].Name = "Class 5";
            dataGridView1.Columns[9].Name = "Class 6";
            dataGridView1.Columns[10].Name = "Class 7";
            dataGridView1.Columns[11].Name = "Class 8";

            foreach (Student student in StudentList)
            {
                int count = 0;
                List<string> SCL = new List<string>() { "", "", "", "", "", "", "", "" };
                foreach (int classid in student.ClassID)
                {
                    SCL[count] = CLR(classid);
                    count++;
                }

                string[] row =
                    new string[] { student.StudentID.ToString(), student.FirstName, student.LastName, student.Grade.ToString(), SCL[0],
                    SCL[1], SCL[2], SCL[3], SCL[4], SCL[5], SCL[6], SCL[7]};
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
