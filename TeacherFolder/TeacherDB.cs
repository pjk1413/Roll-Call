using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Roll_Call.ClassFolder;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;



namespace Roll_Call.TeacherFolder
{
    public static class TeacherDB
    {
        public static void TempSave(Teacher teacher)
        {
            string path = @"Data\tempTeacherEdit.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(teacher.TeacherID);
                    sw.WriteLine(teacher.FirstName);
                    sw.WriteLine(teacher.LastName);
                }
           
        }

        public static Teacher TempLoad()
        {
            Teacher tempTeacher = new Teacher();

            string path = @"Data\tempTeacherEdit.txt";
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

            tempTeacher.TeacherID = Convert.ToInt32(str[0]);
            tempTeacher.FirstName = str[1];
            tempTeacher.LastName = str[2];

            return tempTeacher;
        }

        public static void TeacherSave(Teacher newTeacher)
        {
            string fileName = @"Data\Teachers\" + newTeacher.TeacherID + "_" + newTeacher.LastName + ".json";
            string json = JsonConvert.SerializeObject(newTeacher);

            using (StreamWriter writer = new StreamWriter(fileName,false))
            {
                writer.Write(json);
            }
        }

        public static List<Teacher> TeacherLoad()
        {
            List<Teacher> TeacherList = new List<Teacher>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Teachers\");
            int fileCount = directory.GetFiles().Length;

            //Read and fill all classes based on number of files in class folder

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string json;
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    json = reader.ReadToEnd();
                }
                Teacher newTeacher = JsonConvert.DeserializeObject<Teacher>(json);

                TeacherList.Add(newTeacher);
            }

            return TeacherList;
        }

        public static void TeacherDelete(Teacher teacher)
        {
            List<Teacher> TeacherList = new List<Teacher>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Teachers\");
            int fileCount = directory.GetFiles().Length;

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string fileName = file.Name;
                string[] fileNameArray = fileName.Split('_');
                if (fileNameArray[0] == teacher.TeacherID.ToString())
                {
                    file.Delete();
                }
            }

        }
        
        public static Teacher TeacherFind(int ID) //Loads all data into a teacher object that exists in database
        {
            Teacher findTeacher = new Teacher();
            List<Teacher> TeacherList = TeacherLoad();

            try
            {
                foreach (Teacher t in TeacherList)
                {
                    if (t.TeacherID == ID)
                    {
                        findTeacher = t;
                    }
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("Error finding teacher");
            }

            return findTeacher;
        }

        
    }
}
