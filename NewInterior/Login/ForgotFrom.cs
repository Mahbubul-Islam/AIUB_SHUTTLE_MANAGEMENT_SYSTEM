using NewInterior.Database;
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

namespace NewInterior.Login
{
    public partial class ForgotFrom : Form
    {
        string userId;
        string userName;
        string email;
        public ForgotFrom(string UserID)
        {
            InitializeComponent();
            userId = UserID;
        }

        private void btnLoginHerelb_Click(object sender, EventArgs e)
        {
            LoginFrom login = new LoginFrom();
            login.Show();
            this.Hide();
        }

        private void ForgotFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            userId = txtId.Text.Trim();
            userName = txtWhatName.Text.Trim();
            email = txtWhatEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("All fields are required. Please ensure you have entered your User ID, Name, and Email.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string errorMessage;
            if (ValidateUser(userId, userName, email, out errorMessage))
            {
                // Proceed to create new password
                CreateNewPassword();
            }
            else
            {
                MessageBox.Show(errorMessage, "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValidateUser(string id, string name, string email, out string errorMessage)
        {
            bool isValid = false;
            errorMessage = string.Empty;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open(); // Open the connection here
                string query = "SELECT UserID, Name, Email FROM Users WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@UserID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dbName = reader["Name"].ToString();
                        string dbEmail = reader["Email"].ToString();

                        if (!string.Equals(dbName, name, StringComparison.Ordinal))
                        {
                            errorMessage += "Name does not match. ";
                        }

                        if (!string.Equals(dbEmail, email, StringComparison.Ordinal))
                        {
                            errorMessage += "Email does not match. ";
                        }

                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            isValid = true;
                        }
                    }
                    else
                    {
                        errorMessage = "User ID does not exist.";
                    }
                }
            }

            return isValid;
        }

        private void CreateNewPassword()
        {
            // Logic to create a new password
            MessageBox.Show("Your information has been verified successfully. You can now create a new password.",
                    "Verification Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CreateNewPassword createNewPassword = new CreateNewPassword(userId);
            createNewPassword.Show();
            this.Hide();
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            LoginFrom login = new LoginFrom();
            login.Show();
            this.Hide();
        }
    }
}