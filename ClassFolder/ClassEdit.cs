using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Roll_Call.TeacherFolder;

namespace Roll_Call.ClassFolder
{
    public partial class ClassEdit : Form
    {
        public ClassEdit()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClassEdit_Load(object sender, EventArgs e)
        {
            Classes newClass = ClassesDB.TempLoad();

            txtClassTitle.Text = newClass.ClassTitle;
            cmbTrack.Text = newClass.ClassTrack;
            lblClassID.Text = newClass.ClassID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Classes updatedClass = ClassesDB.ClassFind(Convert.ToInt32(lblClassID.Text));

            updatedClass.ClassID = Convert.ToInt32(lblClassID.Text);
            updatedClass.ClassTitle = txtClassTitle.Text;
            updatedClass.ClassTrack = cmbTrack.Text;

            ClassesDB.ClassDelete(updatedClass);
            ClassesDB.ClassSave(updatedClass);

            MessageBox.Show("Class Updated");

            this.Close();
        }
    }
}
