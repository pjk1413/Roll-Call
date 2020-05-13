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
using Roll_Call.TeacherFolder;
using Roll_Call.ClassFolder;

namespace Roll_Call
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherForm studentForm = new TeacherForm();
            studentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassForm classForm = new ClassForm();
            classForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddClassesStudent newForm = new AddClassesStudent();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignClasses newForm = new AssignClasses();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditTeacher newForm = new EditTeacher();
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClassAddTeacher newForm = new ClassAddTeacher();
            newForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClassEdit newForm = new ClassEdit();
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewAllStudents newForm = new ViewAllStudents();
            newForm.Show();
        }

        //Create a schedule
        private void button11_Click(object sender, EventArgs e)
        {
            SchedulePlan newForm = new SchedulePlan();
            newForm.Show();
        }
    }
}
