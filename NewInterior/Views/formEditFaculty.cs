using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NewInterior.Database;

namespace NewInterior.Views
{
    public partial class formEditFaculty : Form
    {
        string _userId;
        string userIdPattern = "^\\d{4}-\\d{3}-[1-3]$";

        public formEditFaculty(string userID)
        {
            InitializeComponent();
            _userId = userID;
            showData();
        }

        public void showData()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT u.UserID, u.Name, u.Email, u.Password, u.PhoneNumber, u.Address, b.BookingID, b.ShuttleName, b.BookingSeatNumber " +
                               "FROM Users u LEFT JOIN Booking b ON u.UserID = b.UserID WHERE u.UserID = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valueFacultyId.Text = reader["UserID"].ToString();
                            nameTB.Text = reader["Name"].ToString();
                            emailTB.Text = reader["Email"].ToString();
                            passwordTB.Text = reader["Password"].ToString();
                            phoneNumberTB.Text = reader["PhoneNumber"].ToString();
                            cityOrAreaNameTB.Text = reader["Address"].ToString();
                            valueBookingId.Text = reader["BookingID"].ToString();
                            valueShuttleName.Text = reader["ShuttleName"].ToString();
                            bookSeatNumberValue.Text = reader["BookingSeatNumber"].ToString();
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
                MessageBox.Show("Invalid Faculty ID format. It should be XXXX-XXX-X.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string query = "UPDATE Users SET Name=@Name, Email=@Email, Password=@Password, PhoneNumber=@Phone, Address=@Address WHERE UserID=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", nameTB.Text);
                    cmd.Parameters.AddWithValue("@Email", emailTB.Text);
                    cmd.Parameters.AddWithValue("@Password", passwordTB.Text);
                    cmd.Parameters.AddWithValue("@Phone", phoneNumberTB.Text);
                    cmd.Parameters.AddWithValue("@Address", cityOrAreaNameTB.Text);
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Faculty details updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Faculty deleted successfully.");
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnCancleBooking_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Booking WHERE UserID=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Booking canceled successfully.");
            showData();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}