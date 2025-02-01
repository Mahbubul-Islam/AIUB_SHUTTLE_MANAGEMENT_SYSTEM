using NewInterior.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewInterior.userComponents
{
    public partial class formUserManageAccount : UserControl
    {
        public formUserManageAccount()
        {
            InitializeComponent();
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Profile edit_profile = new Edit_Profile();
            edit_profile.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
