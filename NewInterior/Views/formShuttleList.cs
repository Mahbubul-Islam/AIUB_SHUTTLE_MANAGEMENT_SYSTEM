using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewInterior.componentCards;
using NewInterior.Database;

namespace NewInterior.Views
{
    public partial class formShuttleList : Form
    {
        private shuttleCard selectedCard; // Store the currently selected card

        public formShuttleList()
        {
            InitializeComponent();
            showShuttleList();
        }

        private void showShuttleList()
        {
            // Clear any existing controls in the panel (if applicable)
            if (pnlDisplayShuttleList.Controls.Count > 0)
            {
                pnlDisplayShuttleList.Controls.Clear();
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT ShuttleName, Route, Capacity, CONVERT(VARCHAR(8), Time, 108) AS Time FROM Shuttles";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Retrieve data from the database
                        string shuttleName = reader["ShuttleName"].ToString();
                        string route = reader["Route"].ToString();
                        string capacity = reader["Capacity"].ToString();
                        string time = DateTime.Parse(reader["Time"].ToString()).ToString("hh:mm tt");

                        // Create a new shuttleCard with the retrieved data
                        shuttleCard card = new shuttleCard(shuttleName, route, capacity, time)
                        {
                            BackColor = Color.White // Default background color
                        };

                        // Add click event for selecting the card
                        card.Click += (s, e) => SelectCard(card);

                        // Add the card to the panel
                        pnlDisplayShuttleList.Controls.Add(card);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the shuttle list: {ex.Message}");
            }
        }

        private void SelectCard(shuttleCard card)
        {
            // Reset the color of the previously selected card
            if (selectedCard != null)
            {
                selectedCard.BackColor = Color.White;
            }

            // Set the selected card and change its color
            selectedCard = card;
            selectedCard.BackColor = Color.LightGray; // Highlighted color
        }

        private void btnDeleteShuttle_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                MessageBox.Show("Please select a shuttle card to delete.");
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Shuttles WHERE ShuttleName = @ShuttleName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShuttleName", selectedCard.ShuttleName);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Remove the selected card from the panel
                        pnlDisplayShuttleList.Controls.Remove(selectedCard);
                        selectedCard = null; // Reset the selected card
                        MessageBox.Show("Shuttle successfully deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the selected shuttle.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the shuttle: {ex.Message}");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
