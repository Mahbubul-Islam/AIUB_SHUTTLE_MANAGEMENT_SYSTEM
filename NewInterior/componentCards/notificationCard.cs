using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewInterior.componentCards
{
    public partial class notificationCard : UserControl
    {
        private string _userId;

        public notificationCard(string userId, string notificationString, string notificationDateTime)
        {
            InitializeComponent();
            _userId = userId;
            valueNotifiactionString.Text = notificationString;
            valueNotificationDateTime.Text = notificationDateTime;
        }
    }
}
