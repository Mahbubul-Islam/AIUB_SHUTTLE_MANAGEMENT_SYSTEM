using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.Database;
using NewInterior.Models;

namespace NewInterior.Views
{
    public partial class formAddShuttle : Form
    {
        string _shuttleName;
        string _shuttleRoute;
        int _shuttleCapacity = 22; // Default capacity
        string _shuttleTime;
        string adminId = "admin";

        public formAddShuttle()
        {
            InitializeComponent();
        }

        private void getValue()
        {
            _shuttleName = txtShuttleName.Text.Trim();
            _shuttleRoute = txtRoute.Text.Trim();
            _shuttleTime = txtTime.Text.Trim();

            if (!int.TryParse(txtCapacity.Text.Trim(), out _shuttleCapacity))
            {
                _shuttleCapacity = 22; // Fallback to default if parsing fails
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddShuttle_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from input fields
                getValue();

                // Validate input
                if (string.IsNullOrEmpty(_shuttleName) || string.IsNullOrEmpty(_shuttleRoute) || string.IsNullOrEmpty(_shuttleTime))
                {
                    MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Establish connection and insert data
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Shuttles (ShuttleName, Route, Capacity, Time) VALUES (@ShuttleName, @Route, @Capacity, @Time)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ShuttleName", _shuttleName);
                        cmd.Parameters.AddWithValue("@Route", _shuttleRoute);
                        cmd.Parameters.AddWithValue("@Capacity", _shuttleCapacity);
                        cmd.Parameters.AddWithValue("@Time", _shuttleTime);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Shuttle added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MakeNotification.AddNotification(adminId, "A Shuttle is added!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add shuttle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
