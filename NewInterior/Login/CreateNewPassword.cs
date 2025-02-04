using NewInterior.Database;
using NewInterior.Models;
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
using System.Xml.Linq;

namespace NewInterior.Login
{
    public partial class CreateNewPassword : Form
    {
        string Userid;
        string Newpassword;
        string confirmPassword;
        public CreateNewPassword(string userid)
        {
            InitializeComponent();
            Userid = userid;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            LoginFrom login = new LoginFrom();
            login.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Newpassword = txtNewPassword.Text.Trim();
            confirmPassword = txtConfirmPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(Newpassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required. Please enter and confirm your new password.",
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Newpassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password.",
                                 "Mismatch Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string updateQuery = $"UPDATE Users SET Password = '{Newpassword}' WHERE UserID = '{Userid}';";

                var connection = DatabaseConnection.GetConnection();
                connection.Open();
                // Retrieve the current password from the database
                string selectQuery = $"SELECT Password FROM Users WHERE UserID = '{Userid}';";
                var selectCommand = new SqlCommand(selectQuery, connection);
                var currentPassword = selectCommand.ExecuteScalar()?.ToString();

                if (currentPassword == Newpassword)
                {
                    MessageBox.Show("The new password must be different from the previous password.",
                                    "Password Reuse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connection.Close();
                    return;
                }
                // Update the password in the database
                var updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Your password has been reset successfully. You can now log in with your new password.",
                                            "Password Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginFrom login = new LoginFrom();
                login.Show();

                updateCommand.Dispose();
                connection.Close();
                MakeNotification.AddNotification(Userid, $"{Userid} You have changed password!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = chkbShowPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !showPassword;
            txtConfirmPassword.UseSystemPasswordChar = !showPassword;
        }
    }
}

