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
    public partial class shuttleCard : UserControl
    {
        public shuttleCard(string _valueshuttleName, string _valueshuttleRoute, string _valueshuttleCapacity, string _valueshuttleTime)
        {
            InitializeComponent();
            valueShuttleName.Text = _valueshuttleName;
            valueRoute.Text = _valueshuttleRoute;
            valueCapacity.Text = _valueshuttleCapacity;
            valueTime.Text = _valueshuttleTime;
        }
        public string ShuttleName
        {
            get { return valueShuttleName.Text; }
        }
    }
}
