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

namespace Roll_Call.StudentFolder
{
    public partial class AddClassesStudent : Form
    {
        public AddClassesStudent()
        {
            InitializeComponent();
        }

        private void AddClassesStudent_Load(object sender, EventArgs e)
        {
            List<Student> StudentList = StudentDB.StudentLoad();
            foreach (Student student in StudentList)
            {
                string entry = student.StudentID + " " + student.FirstName + " " + student.LastName + " " + student.Grade;
                comboBox1.Items.Add(entry);
            }

            Student newStudent = StudentDB.TempLoad();
            label2.Text = newStudent.StudentID.ToString();
            textBox1.Text = newStudent.FirstName;
            textBox2.Text = newStudent.LastName;

            newStudent = StudentDB.StudentFind(Convert.ToInt32(label2.Text));
            txtGrade.Text = newStudent.Grade.ToString();

            List<Classes> ClassList = ClassesDB.ClassLoad();

            foreach (Classes classes in ClassList)
            {
                checkedListBox1.Items.Add(classes.ClassID + " " + classes.ClassTitle + " " + classes.ClassTrack);
            }
            if (newStudent.ClassID != null)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    foreach (int classid in newStudent.ClassID)
                    {
                        string[] id = checkedListBox1.Items[i].ToString().Split(' ');
                        if (classid == Convert.ToInt32(id[0]))
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        //Save all classes to student 
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = StudentDB.StudentFind(Convert.ToInt32(label2.Text));
            List<int> ClassId = new List<int>();
            foreach (object classid in checkedListBox1.CheckedItems)
            {
                string[] id = classid.ToString().Split(' ');

                ClassId.Add(Convert.ToInt32(id[0]));
                Classes classes = ClassesDB.ClassFind(Convert.ToInt32(id[0]));
                List<int> studentID = new List<int>();
                studentID.Add(classes.ClassID);

                ClassesDB.ClassDelete(classes);
                ClassesDB.ClassSave(classes);
            }

            student.ClassID = ClassId;
            StudentDB.StudentDelete(student);
            StudentDB.StudentSave(student);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] studentID = comboBox1.Text.Split(' ');
            Student newStudent = StudentDB.StudentFind(Convert.ToInt32(studentID[0]));

            label2.Text = newStudent.StudentID.ToString();
            textBox1.Text = newStudent.FirstName;
            textBox2.Text = newStudent.LastName;
            txtGrade.Text = newStudent.Grade.ToString();

            if (newStudent.ClassID != null)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                    foreach (int classid in newStudent.ClassID)
                    {
                        string[] id = checkedListBox1.Items[i].ToString().Split(' ');
                        if (classid == Convert.ToInt32(id[0]))
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }
    }
}
