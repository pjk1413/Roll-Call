using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call
{
    public partial class ScheduleResults : Form
    {
        public ScheduleResults()
        {
            InitializeComponent();
        }

        private void ScheduleResults_Load(object sender, EventArgs e)
        {
            List<Schedule> ScheduleList = Scheduling.ScheduleLoad();

                dataGridView1.ColumnCount = 12;
                dataGridView1.Columns[0].Name = "1st Hour";
                dataGridView1.Columns[1].Name = "2nd Hour";
                dataGridView1.Columns[2].Name = "3rd Hour";
                dataGridView1.Columns[3].Name = "4th Hour";
                dataGridView1.Columns[4].Name = "5th Hour";
                dataGridView1.Columns[5].Name = "6th Hour";
                dataGridView1.Columns[6].Name = "7th Hour";

                /*
                foreach (Student student in StudentList)
                {
                    int count = 0;
                    List<string> SCL = new List<string>() { "", "", "", "", "", "", "", "" };
                    foreach (int classid in student.ClassID)
                    {
                        SCL[count] = CLR(classid);
                        count++;
                    }

                    string[] row =
                        new string[] { student.StudentID.ToString(), student.FirstName, student.LastName, student.Grade.ToString(), SCL[0],
                    SCL[1], SCL[2], SCL[3], SCL[4], SCL[5], SCL[6], SCL[7]};
                    dataGridView1.Rows.Add(row);
                }
                */
            
        }
    }
}
