using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.Database;
using NewInterior.componentCards;

namespace NewInterior.userComponents
{
    public partial class formNotification : UserControl
    {
        private string _userId;

        public formNotification(string userId)
        {
            InitializeComponent();
            _userId = userId;
            showNotification();
        }

        private void showNotification()
        {
            pnlNotificationShow.Controls.Clear();

            string query = "SELECT Message, Date FROM Notifications WHERE UserID = @UserID ORDER BY Date DESC";

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", _userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string notificationString = reader["Message"].ToString();
                                //string notificationDateTime = reader["Date"].ToString();


                                string notificationDateTime = Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy");


                                var notification = new notificationCard(_userId, notificationString, notificationDateTime);
                                pnlNotificationShow.Controls.Add(notification);
                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading notifications: " + ex.Message);
            }
        }
    }
}