using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using NewInterior.Database;
using System.Data.SqlClient;

namespace NewInterior.Views
{
    public partial class Reset_Password : Form
    {
        string userId;
        string Oldpassword;
        string Newpassword;
        string Confirmpassword;

        public Reset_Password(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnResetpass_Click(object sender, EventArgs e)
        {

            Oldpassword = txtOldpass.Text.Trim();
            Newpassword = txtNewpass.Text.Trim();
            Confirmpassword = txtConfirmpass.Text.Trim();

            if (string.IsNullOrWhiteSpace(Oldpassword) || string.IsNullOrWhiteSpace(Newpassword) || string.IsNullOrWhiteSpace(Confirmpassword))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Newpassword != Confirmpassword)
            {
                MessageBox.Show("The new password and confirmation password do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Oldpassword == Newpassword)
            {
                MessageBox.Show("The new password cannot be the same as the old password. Please choose a different password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = $"SELECT Password FROM Users WHERE UserID COLLATE SQL_Latin1_General_CP1_CS_AS ='{userId}';";

                var connection = DatabaseConnection.GetConnection();
                connection.Open();

                var sqlCommand = new SqlCommand(query, connection);
                var dbPassword = sqlCommand.ExecuteScalar()?.ToString();

                if (dbPassword == Oldpassword)
                {
                    string updateQuery = $"UPDATE Users SET Password = '{Newpassword}' WHERE UserID = '{userId}';";
                    var updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Your password has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The old password you entered is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sqlCommand.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting your password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowpass_CheckedChanged_1(object sender, EventArgs e)
        {
            bool showPassword = chkShowpass.Checked;
            txtOldpass.UseSystemPasswordChar = !showPassword;
            txtNewpass.UseSystemPasswordChar = !showPassword;
            txtConfirmpass.UseSystemPasswordChar = !showPassword;
        }
    }
}
