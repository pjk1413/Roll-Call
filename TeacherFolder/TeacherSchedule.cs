using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call.TeacherFolder;

namespace Roll_Call
{
    public partial class TeacherSchedule : Form
    {
        public TeacherSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Teacher> TeacherList = TeacherDB.TeacherLoad();
            Teacher teacher = TeacherDB.TempLoad();

            int[] schedule = { 0, 0, 0, 0, 0, 0, 0, 0};
            List<int> teacherAvailability = new List<int>(schedule);

            for (int i = 0; i < chkListBoxPeriod.Items.Count; i++)
            {
                if (chkListBoxPeriod.GetItemChecked(i))
                {
                    teacherAvailability[i] = 1;
                }
            }

            Teacher newTeacher = TeacherDB.TeacherFind(teacher.TeacherID);
            newTeacher.Availability = teacherAvailability;
            TeacherDB.TeacherDelete(newTeacher);
            TeacherDB.TeacherSave(newTeacher);

            this.Close();
        }

        private void TeacherSchedule_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListBoxPeriod.Items.Count; i++)
            {
                chkListBoxPeriod.SetItemChecked(i, true);
            }
        }
    }
}
