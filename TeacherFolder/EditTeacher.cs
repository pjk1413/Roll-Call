using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Roll_Call.ClassFolder;

namespace Roll_Call.TeacherFolder
{
    public partial class EditTeacher : Form
    {
        public EditTeacher()
        {
            InitializeComponent();
        }

        private void EditTeacher_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Class ID";
            dataGridView1.Columns[1].Name = "Class Title";
            dataGridView1.Columns[2].Name = "Class Track";

            Teacher teacher = TeacherDB.TempLoad();

            lblTeacherID.Text = teacher.TeacherID.ToString();
            txtFirstName.Text = teacher.FirstName;
            txtLastName.Text = teacher.LastName;

            Teacher newTeacher = TeacherDB.TeacherFind(teacher.TeacherID);
            List<Classes> ClassList = new List<Classes>();

            foreach (int classID in newTeacher.ClassID)
            {
                Classes newClass = ClassesDB.ClassFind(classID);
                string[] row = new string[] { newClass.ClassID.ToString(), newClass.ClassTitle, newClass.ClassTrack };
                dataGridView1.Rows.Add(row);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Selected value goes here
            string selected = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            lblID.Text = selected;

            if (lblID.Text == "")
            {
                lblID.Text = "None Selected";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssignClasses newForm = new AssignClasses();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignClasses newForm = new AssignClasses();
            newForm.Show();
        }
    }
}
