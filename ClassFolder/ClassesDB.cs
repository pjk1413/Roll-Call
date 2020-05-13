using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using Roll_Call.TeacherFolder;
using Roll_Call.StudentFolder;
using Newtonsoft.Json;
using System.IO;

namespace Roll_Call.ClassFolder
{
    public static class ClassesDB
    {
        public static void TempSave(Classes classes)
        {
            string path = @"Data\tempClassesEdit.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(classes.ClassID);
                sw.WriteLine(classes.ClassTitle);
                sw.WriteLine(classes.ClassTrack);
            }

        }

        public static List<string> ClassTypes()
        {
            List<string> classTypes = new List<string>();
            classTypes.Add("Math");
            classTypes.Add("Science");
            classTypes.Add("English");
            classTypes.Add("Social Studies");
            classTypes.Add("PE/Health");
            classTypes.Add("Finance");
            classTypes.Add("Elective");

            return classTypes;
        }

        public static Classes TempLoad()
        {
            Classes tempClasses = new Classes();

            string path = @"Data\tempClassesEdit.txt";
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

            tempClasses.ClassID = Convert.ToInt32(str[0]);
            tempClasses.ClassTitle = str[1];
            tempClasses.ClassTrack = str[2];

            return tempClasses;
        }

        public static void ClassSave(Classes newClass)
        {
            string fileName = @"Data\Classes\" + newClass.ClassID + "_" + newClass.ClassTitle + ".json";
            string json = JsonConvert.SerializeObject(newClass);

            foreach (int teachID in newClass.TeacherID)
            {
                if(teachID == 0)
                {
                    newClass.TeacherID.Remove(0);
                }
            }

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine(json);
            }
        }

        public static List<Classes> ClassLoad()
        {
            List<Classes> ClassList = new List<Classes>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Classes\");
            int fileCount = directory.GetFiles().Length;

            //Read and fill all classes based on number of files in class folder

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string json;
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    json = reader.ReadToEnd();
                }
                Classes newClass = JsonConvert.DeserializeObject<Classes>(json);

                ClassList.Add(newClass);
            }

            return ClassList;
        }

        public static void ClassDelete(Classes deleteClass)
        {
            List<Classes> ClassList = new List<Classes>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Classes\");
            int fileCount = directory.GetFiles().Length;

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string fileName = file.Name;
                string[] fileNameArray = fileName.Split('_');
                if (fileNameArray[0] == deleteClass.ClassID.ToString())
                {
                    file.Delete();
                }
            }
        }

        //Returns a fully filled out class
        public static Classes ClassFind (int ID)
        {
            Classes newClass = new Classes();

            List<Classes> ClassList = ClassLoad();

            foreach (Classes c in ClassList)
            {
                if(c.ClassID == ID)
                {
                    newClass = c;
                }
            }

            return newClass;
        }

        public static List<Student> ClassStudentFind(Classes classes)
        {
            List<Student> studentList = new List<Student>();
            List<Student> FullStudentList = StudentDB.StudentLoad();

            foreach (Student student in FullStudentList)
            {
                foreach (int studentClassID in student.ClassID)
                {
                    if(studentClassID == classes.ClassID)
                    {
                        studentList.Add(student);
                    }
                }
            }

            return studentList;
        }
    }
}
