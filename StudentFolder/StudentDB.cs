using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Roll_Call.StudentFolder
{
    class StudentDB
    {
        public static void TempSave(Student student)
        {
            string path = @"Data\tempStudentEdit.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(student.StudentID);
                sw.WriteLine(student.FirstName);
                sw.WriteLine(student.LastName);
            }

        }

        public static Student TempLoad()
        {
            Student tempStudent = new Student();

            string path = @"Data\tempStudentEdit.txt";
            string[] str = new string[3];

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";

                int i = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    str[i] = s;
                    i++;
                }
            }

            tempStudent.StudentID = Convert.ToInt32(str[0]);
            tempStudent.FirstName = str[1];
            tempStudent.LastName = str[2];

            return tempStudent;
        }

        public static void StudentSave(Student newStudent)
        {
            string fileName = @"Data\Students\" + newStudent.StudentID + "_" + newStudent.LastName + ".json";
            string json = JsonConvert.SerializeObject(newStudent);

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine(json);
            }
        }

        public static List<Student> StudentLoad()
        {
            List<Student> StudentList = new List<Student>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Students\");
            int fileCount = directory.GetFiles().Length;

            //Read and fill all classes based on number of files in class folder

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string json;
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    json = reader.ReadToEnd();
                }
                Student newStudent = JsonConvert.DeserializeObject<Student>(json);

                StudentList.Add(newStudent);
            }

            return StudentList;
        }

        public static void StudentDelete(Student student)
        {
            List<Student> StudentList = new List<Student>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Students\");
            int fileCount = directory.GetFiles().Length;

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string fileName = file.Name;
                string[] fileNameArray = fileName.Split('_');
                if (fileNameArray[0] == student.StudentID.ToString())
                {
                    file.Delete();
                }
            }

        }

        public static Student StudentFind(int ID)
        {
            Student findStudent = new Student();

            List<Student> StudentList = StudentLoad();

            try
            {
                foreach (Student t in StudentList)
                {
                    if (t.StudentID == ID)
                    {
                        findStudent = t;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding student");
            }

            return findStudent;
        }
    }
}
