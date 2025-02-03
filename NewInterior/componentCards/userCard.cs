using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.Views;
using NewInterior.Database;

namespace NewInterior.componentCards
{
    public partial class userCard : UserControl
    {
        string _userId;
        string _role;

        public userCard(string _valueUserId, string _valueName, string _valueGmail, string _valueBookingStatus)
        {
            InitializeComponent();
            valueUserId.Text = _valueUserId;
            _userId = _valueUserId;
            valueName.Text = _valueName;
            valueGmail.Text = _valueGmail;
            valueBookingStatus.Text = _valueBookingStatus;
            getRole();
        }

        private void getRole()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Role FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", _userId);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            _role = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching role: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_role == "Student")
            {
                formEditStudent formEditStudent = new formEditStudent(_userId);
                formEditStudent.Show();
            }
            else if (_role == "Faculty")
            {
                formEditFaculty formEditFaculty = new formEditFaculty(_userId);
                formEditFaculty.Show();
            }
            else if (_role == "Staff")
            {
                formEditStuff formEditStuff = new formEditStuff(_userId);
                formEditStuff.Show();
            }
            else
            {
                MessageBox.Show("Invalid role");
            }
        }
    }
}
