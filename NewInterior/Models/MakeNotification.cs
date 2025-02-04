using NewInterior.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterior.Models
{
    internal class MakeNotification
    {
        public static void AddNotification(string userId, string message)
        {
            int notificationId = GetNextNotificationId();
            DateTime sentDate = DateTime.Now;

            string query = @"
                INSERT INTO Notifications (NotificationID, Message, UserID, Date)
                VALUES (@NotificationID, @Message, @UserID, @Date)";

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NotificationID", notificationId);
                        command.Parameters.AddWithValue("@Message", message);
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@Date", sentDate);

                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Notification added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Method to get the next NotificationID manually
        private static int GetNextNotificationId()
        {
            int nextId = 1;

            string query = "SELECT MAX(NotificationID) FROM Notifications";

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            nextId = Convert.ToInt32(result) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the next ID: {ex.Message}");
            }

            return nextId;
        }
    }
}
