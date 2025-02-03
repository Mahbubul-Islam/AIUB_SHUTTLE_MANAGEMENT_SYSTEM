using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NewInterior.userComponents
{
    public partial class formMyBooking : UserControl
    {
        string _userId;
        string _bookingId;
        string _shuttleName;
        string _seatNumber;
        string _bookingStatus;

        public formMyBooking(string UserID)
        {
            InitializeComponent();
            _userId = UserID;
            LoadBookingInfo();
        }

        private void LoadBookingInfo()
        {
            using (SqlConnection conn = Database.DatabaseConnection.GetConnection())
            {
                string query = "SELECT BookingID, ShuttleName, BookingSeatNumber, BookingStatus FROM Booking WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", _userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _bookingId = reader["BookingID"].ToString();
                    _shuttleName = reader["ShuttleName"].ToString();
                    _seatNumber = reader["BookingSeatNumber"].ToString();
                    _bookingStatus = reader["BookingStatus"].ToString();
                }
                conn.Close();
            }
            showInfo();
        }

        private void showInfo()
        {
            userIdValue.Text = _userId;
            valueBookingId.Text = _bookingId;
            valueShattleName.Text = _shuttleName;
            bookSeatNumberValue.Text = _seatNumber;
            valueBooked.Text = _bookingStatus;
        }

        private void btnCancleBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_bookingId))
            {
                MessageBox.Show("No booking found to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Booking WHERE BookingID = @BookingID AND UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookingID", _bookingId);
                    cmd.Parameters.AddWithValue("@UserID", _userId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _bookingId = _shuttleName = _seatNumber = _bookingStatus = string.Empty;
                        showInfo();
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}