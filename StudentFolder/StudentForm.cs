using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call.StudentFolder;
using Roll_Call.ClassFolder;

namespace Roll_Call
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Student> studentList = StudentDB.StudentLoad();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "Grade";

            foreach (Student student in studentList)
            {
                int studentID = student.StudentID;
                string firstName = student.FirstName;
                string lastName = student.LastName;
                string grade = student.Grade.ToString();

                string[] row = new string[] { studentID.ToString(), firstName, lastName, grade };
                dataGridView1.Rows.Add(row);
            }

            int id = 0;
            foreach (Student student in studentList)
            {
                if (student.StudentID >= id)
                {
                    id = student.StudentID + 1;
                }
            }

            studentIDLabel1.Text = id.ToString();

            
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            RefreshTable();
            cmbGrade.Items.Add("9");
            cmbGrade.Items.Add("10");
            cmbGrade.Items.Add("11");
            cmbGrade.Items.Add("12");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSelect.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            List<int> classList = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            student.StudentID = Convert.ToInt32(studentIDLabel1.Text);
            student.FirstName = txtFirstName.Text;
            student.LastName = txtLastName.Text;
            student.Grade = Convert.ToInt32(cmbGrade.Text);
            student.ClassID = classList;
            
            StudentDB.StudentSave(student);
            RefreshTable();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = StudentDB.StudentFind(Convert.ToInt32(lblSelect.Text));

            StudentDB.TempSave(student);

            AddClassesStudent newForm = new AddClassesStudent();
            newForm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSelect.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student deleteStudent = new Student();
            deleteStudent.StudentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            deleteStudent.FirstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            deleteStudent.LastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //Need to check all classes and see if teacher has that class and delete them.
            List<Classes> ListClasses = ClassesDB.ClassLoad();
            
            foreach (Classes classes in ListClasses)
            {
                if (classes.StudentID != null)
                {
                    foreach (int studentid in classes.StudentID)
                    {
                        if (deleteStudent.StudentID == studentid)
                        {
                            classes.StudentID.Remove(studentid);
                            ClassesDB.ClassDelete(classes);
                            ClassesDB.ClassSave(classes);
                        }
                    }
                }
            }

            StudentDB.StudentDelete(deleteStudent);
            RefreshTable();
        }
    }
}
