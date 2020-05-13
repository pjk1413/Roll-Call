using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Roll_Call
{
    public class Classes
    {
        //Constructors

        //Properties
        public int ClassID { get; set; }
        public string ClassType { get; set; }
        public string ClassTitle { get; set; }
        public string ClassTrack { get; set; }
        public List<int> TeacherID { get; set; }
        public List<int> StudentID { get; set; }
        public int Sections { get; set; }
        public List<int> Hour { get; set; }
        
    }
}
