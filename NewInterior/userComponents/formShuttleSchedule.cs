using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewInterior.Database;

namespace NewInterior.userComponents
{
    public partial class formShuttleSchedule : UserControl
    {
        string[] _valueBusNames = new string[8];
        string[] _valueRoutes = new string[8];
        string[] _valueCapacities = new string[8];
        string[] _valueTimes = new string[8];

        Label[] busNameLabels;
        Label[] routeLabels;
        Label[] capacityLabels;
        Label[] timeLabels;

        public formShuttleSchedule()
        {
            InitializeComponent();
            InitializeLabelArrays();
            LoadData();
            showData();
        }

        private void InitializeLabelArrays()
        {
            busNameLabels = new Label[] { valueBusName1, valueBusName2, valueBusName3, valueBusName4, valueBusName5, valueBusName6, valueBusName7, valueBusName8 };
            routeLabels = new Label[] { valueRoute1, valueRoute2, valueRoute3, valueRoute4, valueRoute5, valueRoute6, valueRoute7, valueRoute8 };
            capacityLabels = new Label[] { valueCapacity1, valueCapacity2, valueCapacity3, valueCapacity4, valueCapacity5, valueCapacity6, valueCapacity7, valueCapacity8 };
            timeLabels = new Label[] { valueTime1, valueTime2, valueTime3, valueTime4, valueTime5, valueTime6, valueTime7, valueTime8 };
        }

        private void LoadData()
        {
            for (int i = 0; i < 8; i++)
            {
                _valueBusNames[i] = "N/A";
                _valueRoutes[i] = "N/A";
                _valueCapacities[i] = "N/A";
                _valueTimes[i] = "N/A";
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT TOP 8 ShuttleName, Route, Capacity, Time FROM Shuttles";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int index = 0;
                        while (reader.Read() && index < 8)
                        {
                            _valueBusNames[index] = reader["ShuttleName"].ToString();
                            _valueRoutes[index] = reader["Route"].ToString();
                            _valueCapacities[index] = reader["Capacity"].ToString();
                            _valueTimes[index] = reader["Time"].ToString();
                            index++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void showData()
        {
            for (int i = 0; i < 8; i++)
            {
                busNameLabels[i].Text = _valueBusNames[i];
                routeLabels[i].Text = _valueRoutes[i];
                capacityLabels[i].Text = _valueCapacities[i];
                timeLabels[i].Text = _valueTimes[i];
            }
        }
    }
}