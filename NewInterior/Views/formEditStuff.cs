using NewInterior.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NewInterior.Views
{
    public partial class formEditStuff : Form
    {
        string _userId;
        string userIdPattern = "^\\d{2}-\\d{2}-[1-3]$"; // XX-XX-X

        public formEditStuff(string userId)
        {
            InitializeComponent();
            _userId = userId;
            showData();
        }

        public void showData()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT b.BookingID, b.BookingSeatNumber, b.ShuttleName, u.Email, u.Name, u.Password, u.PhoneNumber, u.Address, u.UserID FROM Users u LEFT JOIN Booking b ON u.UserID = b.UserID WHERE u.UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valueBookingId.Text = reader["BookingID"].ToString();
                            bookSeatNumberValue.Text = reader["BookingSeatNumber"].ToString();
                            valueShuttleName.Text = reader["ShuttleName"].ToString();
                            emailTB.Text = reader["Email"].ToString();
                            nameTB.Text = reader["Name"].ToString();
                            passwordTB.Text = reader["Password"].ToString();
                            phoneNumberTB.Text = reader["PhoneNumber"].ToString();
                            cityOrAreaNameTB.Text = reader["Address"].ToString();
                            valueStuffId.Text = reader["UserID"].ToString();
                        }
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(nameTB.Text) ||
                string.IsNullOrWhiteSpace(emailTB.Text) ||
                string.IsNullOrWhiteSpace(passwordTB.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberTB.Text) ||
                string.IsNullOrWhiteSpace(cityOrAreaNameTB.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(_userId, userIdPattern))
            {
                MessageBox.Show("Invalid Stuff ID format. It should be XX-XX-X.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!emailTB.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email format. Email must contain '@'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Email = @Email, Name = @Name, Password = @Password, PhoneNumber = @PhoneNumber, Address = @Address WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", emailTB.Text);
                    cmd.Parameters.AddWithValue("@Name", nameTB.Text);
                    cmd.Parameters.AddWithValue("@Password", passwordTB.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumberTB.Text);
                    cmd.Parameters.AddWithValue("@Address", cityOrAreaNameTB.Text);
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("User details updated successfully.");
        }

        private void btnCancleBooking_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Booking WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Booking canceled successfully.");
            showData();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("User deleted successfully.");
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}