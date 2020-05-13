using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call.ClassFolder;

namespace Roll_Call.TeacherFolder
{
    public partial class AssignClasses : Form
    {
        public AssignClasses()
        {
            InitializeComponent();
        }

        private void AssignClasses_Load(object sender, EventArgs e)
        {
            List<Teacher> TeacherList = TeacherDB.TeacherLoad();
            List<Classes> ClassList = ClassesDB.ClassLoad();

            foreach (Classes classes in ClassList)
            {
                string className = classes.ClassID + " " + classes.ClassTitle + " " + classes.ClassTrack;
                checkedListBox1.Items.Add(className, false);
            }

            foreach (Teacher teacher in TeacherList)
            {
                comboBox1.Items.Add(teacher.TeacherID + " " + teacher.FirstName + " " + teacher.LastName);
            }

        }

        private void btnSave_Click(object sender, EventArgs e) //Needs validation
        {
            if (true) //Validate everything
            {
                List<int> ClassList = new List<int>();
                List<Classes> ClassListSave = new List<Classes>();

                //Retrieves class data and populates list
                foreach (object classData in checkedListBox1.CheckedItems)
                {
                    string[] classInfo = classData.ToString().Split(' ');

                    Classes newClass = ClassesDB.ClassFind(Convert.ToInt32(classInfo[0]));
                    ClassListSave.Add(newClass);
                    ClassList.Add(newClass.ClassID);
                }

                //Find teacher and add data into teacher
                string[] teacherID = comboBox1.Text.Split(' ');

                Teacher newTeacher = TeacherDB.TeacherFind(Convert.ToInt32(teacherID[0]));
                newTeacher.ClassID = ClassList;

                foreach (Classes classes in ClassListSave)
                {
                    classes.TeacherID.Add(newTeacher.TeacherID);

                    ClassesDB.ClassDelete(classes);
                    ClassesDB.ClassSave(classes);
                }

                TeacherDB.TeacherDelete(newTeacher);
                TeacherDB.TeacherSave(newTeacher);
            }
            else
            {
                MessageBox.Show("Please select the correct number of classes or select a different teacher");
            }

            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            List<Teacher> TeacherList = TeacherDB.TeacherLoad();
            List<Classes> ClassList = ClassesDB.ClassLoad();

            string[] teacherName = comboBox1.Text.Split(' ');
            Teacher teacher = TeacherDB.TeacherFind(Convert.ToInt32(teacherName[0]));

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string[] classid = checkedListBox1.Items[i].ToString().Split(' ');

                foreach (int id in teacher.ClassID)
                {
                    if(Convert.ToInt32(classid[0]) == id)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }
    }
}
