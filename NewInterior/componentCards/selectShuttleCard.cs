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
    public partial class selectShuttleCard : UserControl
    {
        
        public selectShuttleCard(string _valueShuttleName, string _valueShuttleRoute, string _valueTime)
        {
            InitializeComponent();
            valueShuttleName.Text = _valueShuttleName;
            valueRoute.Text = _valueShuttleRoute;
            valueTime.Text = _valueTime;
        }
    }
}

