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
using Roll_Call.StudentFolder;



namespace Roll_Call
{
    public partial class SchedulePlan : Form
    {
        public SchedulePlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scheduling.ScheduleClassCompatibility(Convert.ToInt32(txtErrors.Text));
            ScheduleResults newForm = new ScheduleResults();
            newForm.Show();
        }

        private void SchedulePlan_Load(object sender, EventArgs e)
        {
            List<Classes> ClassList = ClassesDB.ClassLoad();
            List<Teacher> TeacherList = TeacherDB.TeacherLoad();
            List<Student> StudentList = StudentDB.StudentLoad();

            txtClasses.Text = ClassList.Count.ToString();
            txtStudents.Text = StudentList.Count.ToString();
            txtTeachers.Text = TeacherList.Count.ToString();
            txtErrors.Text = "3";
            txtClassSize.Text = "10"; //Needs to be set based on a formula (Total Teachers, Periods, Classes and Students)

            int classSize = Convert.ToInt32(txtClassSize.Text);
            double classesPerHour = StudentList.Count / classSize;

            txtClassesPerHour.Text = classesPerHour.ToString();

        }

        private void txtErrors_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
