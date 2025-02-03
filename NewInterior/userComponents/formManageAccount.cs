using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.componentCards;
using NewInterior.Database;
using NewInterior.Views;

namespace NewInterior.userComponents
{
    public partial class formManageAccount : UserControl
    {
        string _txtSearch;
        string _Id;
        string _Name;

        public formManageAccount()
        {
            InitializeComponent();
            rbStudent.Checked = true;
            ShowUser("Student", "");

            rbStudent.CheckedChanged += (s, e) => { if (rbStudent.Checked) ShowUser("Student", txtSearch.Text.Trim()); };
            rbFaculty.CheckedChanged += (s, e) => { if (rbFaculty.Checked) ShowUser("Faculty", txtSearch.Text.Trim()); };
            rbStaff.CheckedChanged += (s, e) => { if (rbStaff.Checked) ShowUser("Staff", txtSearch.Text.Trim()); };
        }

        public void ShowUser(string selectedRole, string searchQuery)
        {
            userShowflowLayoutPanel.Controls.Clear();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Users.UserID, Users.Name, Users.Email, Booking.BookingStatus FROM Users " +
                               "LEFT JOIN Booking ON Users.UserID = Booking.UserID " +
                               "WHERE Users.Role = @Role AND (Users.UserID LIKE @Search OR Users.Name LIKE @Search OR Users.Email LIKE @Search)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Role", selectedRole);
                    cmd.Parameters.AddWithValue("@Search", $"%{searchQuery}%"); // Search by ID, Name, Email

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userCard user = new userCard(
                                reader["UserID"].ToString(),
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["BookingStatus"] != DBNull.Value ? reader["BookingStatus"].ToString() : "N/A"
                            );
                            userShowflowLayoutPanel.Controls.Add(user);
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            formAddStudent addStudent = new formAddStudent();
            addStudent.Show();
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            formAddFaculty addFaculty = new formAddFaculty();
            addFaculty.Show();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            formAddStuff addStuff = new formAddStuff();
            addStuff.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _txtSearch = txtSearch.Text.Trim();
            if (rbStudent.Checked)
            {
                ShowUser("Student", _txtSearch);
            }
            else if (rbFaculty.Checked)
            {
                ShowUser("Faculty", _txtSearch);
            }
            else if (rbStaff.Checked)
            {
                ShowUser("Staff", _txtSearch);
            }
        }
    }
}
