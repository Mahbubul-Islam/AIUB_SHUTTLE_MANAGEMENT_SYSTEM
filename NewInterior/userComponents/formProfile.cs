using NewInterior.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NewInterior.userComponents
{
    public partial class formProfile : UserControl
    {
        string _IdValue;
        string _NameValue;
        string _EmailValue;
        string _PhoneValue;
        string _NationalityValue;
        string _AddressValue;
        string _GenderValue;
        string _DOBValue;
        string _RoleValue;
        string _StatusValue;
        string _bloodGroupValue;

        public formProfile(string userId)
        {
            InitializeComponent();
            _IdValue = userId;
            LoadUserProfile(); // Fetch user data
            showProfile();     // Update UI with user data
        }

        private void LoadUserProfile()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Name, Email, PhoneNumber, Nationality,BloodGroup, Address, Gender, Dob, Role FROM Users WHERE UserID = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", _IdValue);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _NameValue = reader["Name"].ToString();
                                _EmailValue = reader["Email"].ToString();
                                _PhoneValue = reader["PhoneNumber"].ToString();
                                _NationalityValue = reader["Nationality"].ToString();
                                _AddressValue = reader["Address"].ToString();
                                _GenderValue = reader["Gender"].ToString();
                                _DOBValue = reader["Dob"].ToString();
                                _RoleValue = reader["Role"].ToString();
                                _bloodGroupValue = reader["BloodGroup"].ToString();
                            }
                        }
                    }
                }

                // Fetch Booking Status
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string bookingQuery = "SELECT BookingStatus FROM Booking WHERE UserID = @UserId ORDER BY BookedTime DESC";
                    using (SqlCommand cmd = new SqlCommand(bookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", _IdValue);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _StatusValue = reader["BookingStatus"].ToString();
                            }
                            else
                            {
                                _StatusValue = "No Bookings";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user profile: " + ex.Message);
            }
        }

        public void showProfile()
        {
            idValue.Text = _IdValue;
            nameValue.Text = _NameValue;
            emailValue.Text = _EmailValue;
            phoneValue.Text = _PhoneValue;
            NationalityValue.Text = _NationalityValue;
            AddressValue.Text = _AddressValue;
            GenderValue.Text = _GenderValue;
            DobValue.Text = _DOBValue;
            roleValue.Text = _RoleValue;
            BookingStatusValue.Text = _StatusValue;
            BloodGroupValue.Text = _bloodGroupValue;
        }

        private void detailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
