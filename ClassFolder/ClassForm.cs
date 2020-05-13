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
using System.IO;
using Roll_Call.ClassFolder;
using Roll_Call.TeacherFolder;

namespace Roll_Call
{
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            RefreshTable();
            
        }

        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Classes> classList = new List<Classes>();
            classList = ClassesDB.ClassLoad();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Class ID";
            dataGridView1.Columns[1].Name = "Class Title";
            dataGridView1.Columns[2].Name = "Class Track";

            foreach (Classes classes in classList)
            {
                string[] row;
                row = new string[] { classes.ClassID.ToString(), classes.ClassTitle, classes.ClassTrack };
              
                dataGridView1.Rows.Add(row);
            }

            int id = 0;
            foreach (Classes classes in classList)
            {
                if (classes.ClassID >= id)
                {
                    id = classes.ClassID + 1;
                }
            }

            classIDLabel1.Text = id.ToString();
        }

        //Add a teacher to an existing class
        private void button1_Click(object sender, EventArgs e)
        {
            //Add a student
                ClassAddTeacher newForm = new ClassAddTeacher();
                newForm.Show();
        }

        //Save a new class
        private void button3_Click(object sender, EventArgs e)
        {
            Classes newClass = new Classes();

            List<int> teacherID = new List<int>() { 0, 0, 0, 0 };

            newClass.ClassID = Convert.ToInt32(classIDLabel1.Text);
            newClass.ClassTitle = txtTitle.Text;
            newClass.Sections = 1;
            newClass.TeacherID = teacherID;

            if (comboBox1.Text == "")
            {
                newClass.ClassTrack = "A";
            }
            else
            {
                newClass.ClassTrack = comboBox1.Text;
            }
                
            ClassesDB.ClassSave(newClass);
            RefreshTable();
        }    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            lblSelected.Text = selected;

            if(lblSelected.Text == "Selected")
            {
                lblSelected.Text = "1";
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // lblSelected
        }

        private void ClassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Place a cross reference load command here
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblSelected.Text == "")
            {
                MessageBox.Show("Please select a class to delete");
            }
            else
            {
                Classes newClasses = new Classes();
                int classNum = Convert.ToInt32(lblSelected.Text);

                newClasses.ClassID = classNum;
                ClassesDB.ClassDelete(newClasses);

                List<Teacher> teacherList = TeacherDB.TeacherLoad();
                foreach (Teacher teacher in teacherList)
                {
                    foreach (int classid in teacher.ClassID)
                    {
                        if(classid == newClasses.ClassID)
                        {
                            teacher.ClassID.Remove(classid);
                            TeacherDB.TeacherDelete(teacher);
                            TeacherDB.TeacherSave(teacher);
                        }
                    }
                }

                RefreshTable();
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lblSelected.Text != "")
            {
                Classes newClass = new Classes();
                newClass.ClassID = Convert.ToInt32(lblSelected.Text);
                newClass.ClassTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                newClass.ClassTrack = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                ClassesDB.TempSave(newClass);

                ClassEdit newForm = new ClassEdit();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a class to modify");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
    }
}
