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
    public partial class formProfile : UserControl
    {
        //string _userId;

        public formProfile(string userId)
        {
            InitializeComponent();
            //_userId = userId;
            //lblId.Text = _userId;
        }

        private void Lbleditinfo_Click(object sender, EventArgs e)
        {
            Edit_Profile edit_Profile = new Edit_Profile();
            edit_Profile.Show();
        }
    }
}
