using NewInterior.Database;
using NewInterior.userComponents;
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
    public partial class LoginFrom : Form
    {

        ForgotFrom forgotFrom;
        RegisterForm registerForm = new RegisterForm();


        string _userId;
        string _password;

        public LoginFrom()
        {
            InitializeComponent();
            forgotFrom = new ForgotFrom(_userId);
        }

        private void btnSinguplbl_Click(object sender, EventArgs e)
        {
            registerForm.Show();
            this.Hide();
        }

        // ... rest of the code

        private void btnForgotPasswordlbl_Click(object sender, EventArgs e)
        {
            forgotFrom.Show();
            this.Hide();
        }

        private void LoginFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _userId = txtName.Text.Trim();
            _password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(_userId) || string.IsNullOrWhiteSpace(_password))
            {
                return;
            }

            string query = $"SELECT COUNT(*) FROM Users WHERE UserID COLLATE SQL_Latin1_General_CP1_CS_AS ='{_userId}'  AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = '{_password}';";

            var connection = DatabaseConnection.GetConnection();
            connection.Open();

            var sqlCommand = new SqlCommand(query, connection);


            int userCount = (int)sqlCommand.ExecuteScalar(); // 0 or 1

            if (userCount > 0)
            {
                this.Hide();
                Form1 form1 = new Form1(_userId);
                form1.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sqlCommand.Dispose();
            connection.Dispose();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
