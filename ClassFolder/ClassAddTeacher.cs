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

namespace Roll_Call.ClassFolder
{
    public partial class ClassAddTeacher : Form
    {
        public void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Classes> classList = ClassesDB.ClassLoad();
            List<Teacher> teacherList = TeacherDB.TeacherLoad();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Class ID";
            dataGridView1.Columns[1].Name = "Class Title";
            dataGridView1.Columns[2].Name = "Class Track";
            dataGridView1.Columns[3].Name = "Teacher";
            dataGridView1.Columns[4].Name = "Teacher(s)";
            dataGridView1.Columns[5].Name = "Teacher(s)";
            dataGridView1.Columns[6].Name = "Teacher(s)";

            foreach (Classes classes in classList)
            {
                string[] row;
                List<string> teacherNames = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
                int count = 0;
                foreach (int teacherid in classes.TeacherID)
                {
                    if(teacherid != 0)
                    {
                        Teacher newTeacher = TeacherDB.TeacherFind(teacherid);
                        teacherNames[count] = newTeacher.TeacherID.ToString() + " " + newTeacher.FirstName + " " + newTeacher.LastName;
                        count++;
                    }
                }

                row = new string[] { classes.ClassID.ToString(), classes.ClassTitle, classes.ClassTrack, teacherNames[0], teacherNames[1], teacherNames[2], teacherNames[3] };
                dataGridView1.Rows.Add(row);
            }   
        }

        public ClassAddTeacher()
        {
            InitializeComponent();
        }

        private void ClassAddTeacher_Load(object sender, EventArgs e)
        {
            RefreshTable();

            List<Classes> ClassList = ClassesDB.ClassLoad();
            List<Teacher> TeacherList = TeacherDB.TeacherLoad();

            foreach (Classes classes in ClassList)
            {
                cmbClasses.Items.Add(classes.ClassID.ToString() + " " + classes.ClassTitle);
            }

            foreach (Teacher teacher in TeacherList)
            {
                cmbTeachers.Items.Add(teacher.TeacherID + " " + teacher.FirstName + " " + teacher.LastName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            string[] Name = cmbTeachers.Text.Split(' ');
            string[] Title = cmbClasses.Text.Split(' ');
            Teacher teacher = TeacherDB.TeacherFind(Convert.ToInt32(Name[0]));
            Classes classes = ClassesDB.ClassFind(Convert.ToInt32(Title[0]));

            foreach (int teacherId in classes.TeacherID)
            {
                if(teacherId == teacher.TeacherID)
                {
                    MessageBox.Show("Teacher already part of class");
                    return; ;
                }
            }

            classes.TeacherID.RemoveAll(item => item == 0);

            classes.TeacherID.Add(teacher.TeacherID);
            teacher.ClassID.Add(classes.ClassID);

            ClassesDB.ClassDelete(classes);
            ClassesDB.ClassSave(classes);

            TeacherDB.TeacherDelete(teacher);
            TeacherDB.TeacherSave(teacher);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] Name = cmbTeachers.Text.Split(' ');
            string[] Title = cmbClasses.Text.Split(' ');
            Teacher teacher = TeacherDB.TeacherFind(Convert.ToInt32(Name[0]));
            Classes classes = ClassesDB.ClassFind(Convert.ToInt32(Title[0]));

            classes.TeacherID.Remove(teacher.TeacherID);
            teacher.ClassID.Remove(classes.ClassID);

            ClassesDB.ClassDelete(classes);
            ClassesDB.ClassSave(classes);

            TeacherDB.TeacherDelete(teacher);
            TeacherDB.TeacherSave(teacher);

        }
    }
}
