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
        
        public notificationCard(string notificationString, string notificationDateTime)
        {
            InitializeComponent();
            
            valueNotifiactionString.Text = notificationString;
            valueNotificationDateTime.Text = notificationDateTime; 
        }

    }
}
