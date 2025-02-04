using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewInterior.Views;

namespace NewInterior.userComponents
{
    public partial class formHome : UserControl
    {
        string _userId;
        
        public formHome( string userId)
        {
            InitializeComponent();
            
            _userId = userId;

        }
        
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            Edit_Profile edit_Profile = new Edit_Profile(_userId);
            edit_Profile.Show();
        }
    }
}
