using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll_Call.ClassFolder;
using Roll_Call.StudentFolder;
using Roll_Call.TeacherFolder;
using Newtonsoft.Json;
using System.IO;

namespace Roll_Call
{
    public static class Scheduling
    {
        public static List<Schedule> ScheduleLoad()
        {
            List<Schedule> ScheduleList = new List<Schedule>();
            DirectoryInfo directory = new DirectoryInfo(@"Data\Schedule\");
            int fileCount = directory.GetFiles().Length;

            //Read and fill all classes based on number of files in class folder

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                string json;
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    json = reader.ReadToEnd();
                }
                Schedule newSchedule = JsonConvert.DeserializeObject<Schedule>(json);

                ScheduleList.Add(newSchedule);
            }

            return ScheduleList;
        }

        public static void ScheduleClassCompatibility(int errorLimit, int maxClassSize)
        {
            //Establish Variables
            Schedule schedule = new Schedule();
            List<Classes> ClassList = ClassesDB.ClassLoad();
            List<Student> StudentList = StudentDB.StudentLoad();
            int errorCount = 0;
            
            //Compares students from each class and determines which classes have no matches
            for (int i = 0; i < ClassList.Count; i++) //Loops through all classes
            {
                List<Student> studentList1 = ClassesDB.ClassStudentFind(ClassList[i]); //List for current class
                List<Classes> CompatibleClasses = new List<Classes>();
                List<Classes> IncompatibleClasses = new List<Classes>();
                List<int> incompatibleErrors = new List<int>();

                for (int x = i+1; x < ClassList.Count; x++) //Loops through all classes and compares to existing class
                {
                    List<Student> studentList2 = ClassesDB.ClassStudentFind(ClassList[x]); //List for compared class 

                    foreach (Student student1 in studentList1)
                    {
                        foreach (Student student2 in studentList2)
                        {
                            if (ClassList[i].TeacherID == ClassList[x].TeacherID)
                            {
                                errorCount += 10;
                            }
                            if (student1.StudentID == student2.StudentID)
                            {
                                errorCount++;
                            }
                        }
                    }

                    if(errorCount > errorLimit)
                    {
                        IncompatibleClasses.Add(ClassList[x]);
                        incompatibleErrors.Add(errorCount);
                    }
                    else
                    {
                        CompatibleClasses.Add(ClassList[x]);
                    }
                }

                schedule.PrincipleClass = ClassList[i];
                schedule.CompatibleClasses = CompatibleClasses;
                schedule.IncompatibleClasses = IncompatibleClasses;
                schedule.IncompatibleErrors = incompatibleErrors;

                //Save 
                File.Delete(@"Data\Schedule\ScheduleData_" + i + ".json");
                string fileName = @"Data\Schedule\ScheduleData_" + i + ".json";
                string json = JsonConvert.SerializeObject(schedule);

                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.WriteLine(json);
                }
            }
        }

        public static void PeriodConstructor(int totalTeachers, int maxClassSize)
        {
            //Find teacher availabilty to determine max classes per hour (store in a list that is zero indexed)
            //Take the number of teachers and the desired class size and use that to determine the number of classes each hour

            List<Teacher> TeacherList = TeacherDB.TeacherLoad();
            List<int> AvailableSlots = new List<int>();

            //For loop gains total number of available slots, zero indexed
            foreach (Teacher teacher in TeacherList)
            {
                for (int i = 0; i < teacher.Availability.Count; i++)
                {
                    if(teacher.Availability[i] == 1)
                    {
                        AvailableSlots[i] += 1;
                    }
                }
            }

            //Start with first class in the list, place the remaing x number of compatible classes
            List<Schedule> Schedules = ScheduleLoad();
            


            //Move to 2nd Period, place next classes
        }
    }

    public class ScheduleClass
    {
        public int CurrentHour { get; set; }
        public List<Classes> ClassList { get; set; }
    }

    public class Schedule
    {
        public Classes PrincipleClass { get; set; }
        public List<Classes> CompatibleClasses { get; set; }
        public List<int> IncompatibleErrors { get; set; }
        public List<Classes> IncompatibleClasses { get; set; }
    }
}
