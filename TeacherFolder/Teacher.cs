using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Roll_Call.TeacherFolder;

namespace Roll_Call
{
    public class Teacher
    {
        //Constructor

        //Properties
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Availability { get; set; }
        public List<int> ClassID { get; set; }
    }

}


    

