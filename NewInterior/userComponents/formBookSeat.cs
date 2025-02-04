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
using NewInterior.componentCards;
using NewInterior.Models;

namespace NewInterior.userComponents
{
    public partial class formBookSeat : UserControl
    {
        int _bookingId;
        string _valueUserId;
        string _valueSelectedShuttle;
        string _valueSelectedSeat;

        public formBookSeat(string userID)
        {
            InitializeComponent();
            _valueUserId = userID;
            showShuttleList();
            InitializeRadioButtons();
        }

        private void showShuttleList()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ShuttleName, Route, Time FROM Shuttles";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string shuttleName = reader["ShuttleName"].ToString();
                            string route = reader["Route"].ToString();
                            string time = reader["Time"].ToString();

                            selectShuttleCard card = new selectShuttleCard(shuttleName, route, time);
                            card.Dock = DockStyle.Top;
                            card.Click += (s, e) => SelectShuttle(card, shuttleName);
                            selectShuttleCarddisppnl.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectShuttle(selectShuttleCard selectedCard, string shuttleName)
        {
            foreach (Control control in selectShuttleCarddisppnl.Controls)
            {
                if (control is selectShuttleCard card)
                {
                    card.BackColor = Color.White;
                }
            }
            selectedCard.BackColor = Color.LightBlue;
            _valueSelectedShuttle = shuttleName;
            selectedBusTB.Text = shuttleName;
        }

        private void InitializeRadioButtons()
        {
            foreach (Control control in seatSelectionPanel.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += SelectSeat;
                }
            }
        }

        private void SelectSeat(object sender, EventArgs e)
        {
            RadioButton selectedRadio = sender as RadioButton;
            if (_valueSelectedSeat != null)
            {
                MessageBox.Show("Maximum booking reached", "Booking Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                selectedRadio.Checked = false;
                return;
            }

            _valueSelectedSeat = selectedRadio.Text;
            selectedSeatTB.Text = _valueSelectedSeat;
        }

        private void btnConfirmBookin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_valueSelectedShuttle) || string.IsNullOrEmpty(_valueSelectedSeat))
            {

                MessageBox.Show("Please select a bus and a seat before confirming your booking.", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Booking WHERE UserID = @UserID AND ShuttleName = @ShuttleName";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@UserID", _valueUserId);
                        checkCommand.Parameters.AddWithValue("@ShuttleName", _valueSelectedShuttle);
                        int existingBookings = (int)checkCommand.ExecuteScalar();

                        if (existingBookings > 0)
                        {
                            MessageBox.Show("You have already booked a seat for this shuttle.", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string seatCheckQuery = "SELECT COUNT(*) FROM Booking WHERE ShuttleName = @ShuttleName AND BookingSeatNumber = @BookingSeatNumber";
                    using (SqlCommand seatCheckCommand = new SqlCommand(seatCheckQuery, connection))
                    {
                        seatCheckCommand.Parameters.AddWithValue("@ShuttleName", _valueSelectedShuttle);
                        seatCheckCommand.Parameters.AddWithValue("@BookingSeatNumber", _valueSelectedSeat);
                        int seatBookings = (int)seatCheckCommand.ExecuteScalar();

                        if (seatBookings > 0)
                        {
                            MessageBox.Show("This seat is already booked.", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bookingId = GenerateBookingId();
            DateTime bookedTime = DateTime.Now;

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Booking (BookingID, ShuttleName, UserID, BookingSeatNumber, BookingStatus, BookedTime) VALUES (@BookingID, @ShuttleName, @UserID, @BookingSeatNumber, @BookingStatus, @BookedTime)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", _bookingId);
                        command.Parameters.AddWithValue("@ShuttleName", _valueSelectedShuttle);
                        command.Parameters.AddWithValue("@UserID", _valueUserId);
                        command.Parameters.AddWithValue("@BookingSeatNumber", _valueSelectedSeat);
                        command.Parameters.AddWithValue("@BookingStatus", "Booked");
                        command.Parameters.AddWithValue("@BookedTime", bookedTime);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking Confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MakeNotification.AddNotification(_valueUserId, $"{_valueUserId} Your booking is confirmed! Booking ID {_bookingId}");
                        }
                        else
                        {
                            MessageBox.Show("Booking failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GenerateBookingId()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
