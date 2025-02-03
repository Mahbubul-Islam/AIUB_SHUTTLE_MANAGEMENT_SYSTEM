using NewInterior.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.Views;

namespace NewInterior.userComponents
{
    public partial class formDashboard : UserControl
    {
        
        public formDashboard()
        {
            InitializeComponent();
            upOverAllData();
        }

       
        public void upOverAllData()
        {
            int totalStaff = 0, totalFaculty = 0, totalStudent = 0, totalBookedSeat = 0, totalBus = 0;

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

               
                    string staffQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Staff'";
                    string facultyQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Faculty'";
                    string studentQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Student'";
                
                totalStaff = ExecuteScalarQuery(staffQuery, connection);
                    totalFaculty = ExecuteScalarQuery(facultyQuery, connection);
                    totalStudent = ExecuteScalarQuery(studentQuery, connection);
                

                
                string bookedSeatsQuery = "SELECT COUNT(BookingSeatNumber) FROM Booking WHERE BookingStatus = 'Booked' AND BookingSeatNumber IS NOT NULL;";
                totalBookedSeat = ExecuteScalarQuery(bookedSeatsQuery, connection);

                
                string busQuery = "SELECT COUNT(*) FROM Shuttles";
                totalBus = ExecuteScalarQuery(busQuery, connection);

                connection.Close();
            }

            
            valueTotalStaff.Text = totalStaff.ToString();
            valueTotalFaculty.Text = totalFaculty.ToString();
            valueTotalStudent.Text = totalStudent.ToString();
            valueTotalBookedSeat.Text = totalBookedSeat.ToString();
            valueTotalBus.Text = totalBus.ToString();
        }

       
        private int ExecuteScalarQuery(string query, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private void btnShuttleList_Click(object sender, EventArgs e)
        {
            formShuttleList shuttleList = new formShuttleList();
            shuttleList.Show();
        }

        private void btnAddShuttle_Click(object sender, EventArgs e)
        {
            formAddShuttle addShuttle = new formAddShuttle();
            addShuttle.Show();
        }
    }
}
