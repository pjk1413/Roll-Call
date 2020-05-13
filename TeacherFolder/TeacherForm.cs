using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using Roll_Call.TeacherFolder;
using System.IO;
using Roll_Call.ClassFolder;

namespace Roll_Call
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Teacher> teacherList = new List<Teacher>();
            teacherList = TeacherDB.TeacherLoad();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Teacher ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";

            foreach (Teacher teacher in teacherList)
            {
                string[] row = new string[] { teacher.TeacherID.ToString(), teacher.FirstName, teacher.LastName };
                dataGridView1.Rows.Add(row);
            }

            int id = 0;
            foreach (Teacher teacher in teacherList)
            {
                if(teacher.TeacherID >= id)
                {
                    id = teacher.TeacherID + 1;
                }
            }

            teacherIDLabel1.Text = id.ToString();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void hours_AvailableTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //hours_AvailableTextBox.Text = "7";
        }

        //Adjust teacher availability
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lblSelected.Text != "")
            {
                Teacher teacher = new Teacher();
                teacher.TeacherID = Convert.ToInt32(lblSelected.Text);
                teacher.FirstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                teacher.LastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                TeacherDB.TempSave(teacher);

                TeacherSchedule newTeacherSchedule = new TeacherSchedule();
                newTeacherSchedule.Show();
            }
            else
            {
                MessageBox.Show("Please select a teacher to modify");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<int> teacherAvailability = new List<int>() { 1, 1, 1, 1, 1, 1, 1 };
            List<int> classListID = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
            Teacher newTeacher = new Teacher();

            newTeacher.FirstName = txtFirstName.Text;
            newTeacher.LastName = txtLastName.Text;
            newTeacher.TeacherID = Convert.ToInt32(teacherIDLabel1.Text);
            newTeacher.Availability = teacherAvailability;
            newTeacher.ClassID = classListID;

            TeacherDB.TeacherSave(newTeacher);

            RefreshTable();

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;

            MessageBox.Show("Teacher Saved");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Teacher deleteTeacher = new Teacher();
            deleteTeacher.TeacherID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            deleteTeacher.FirstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            deleteTeacher.LastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //Need to check all classes and see if teacher has that class and delete them.
            List<Classes> ListClasses = ClassesDB.ClassLoad();
            foreach (Classes classes in ListClasses)
            {
                foreach (int teacherid in classes.TeacherID)
                {
                    if(deleteTeacher.TeacherID == teacherid)
                    {
                        classes.TeacherID.Remove(teacherid);
                        ClassesDB.ClassDelete(classes);
                        ClassesDB.ClassSave(classes);
                    }
                }
            }

            TeacherDB.TeacherDelete(deleteTeacher);
            RefreshTable();
        }

        //Select teacher marker
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            lblSelected.Text = selected;
        }

        //Modify a Teacher
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lblSelected.Text != "")
            {
                Teacher teacher = new Teacher();

                teacher.TeacherID = Convert.ToInt32(lblSelected.Text);
                teacher.FirstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                teacher.LastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                TeacherDB.TempSave(teacher);

                EditTeacher newForm = new EditTeacher();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a teacher to modify");
            }
            
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            AssignClasses newForm = new AssignClasses();
            newForm.Show();
        }
    }
}
