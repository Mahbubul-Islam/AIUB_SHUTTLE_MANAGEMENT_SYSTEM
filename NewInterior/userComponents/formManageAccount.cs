using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewInterior.Views;
using System.Windows.Forms;

namespace NewInterior.userComponents
{
    public partial class formManageAccount : UserControl
    {
        public formManageAccount()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            formAddStudent addStudent = new formAddStudent();
            addStudent.Show();
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            formAddFaculty addFaculty = new formAddFaculty();
            addFaculty.Show();
        }

        

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            formAddStuff addStuff = new formAddStuff();
            addStuff.Show();
        }
    }
}
