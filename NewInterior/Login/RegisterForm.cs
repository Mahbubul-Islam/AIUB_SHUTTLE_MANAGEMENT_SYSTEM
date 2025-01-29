using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NewInterior.Database;

namespace NewInterior.Login
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnLoginHerelbl_Click(object sender, EventArgs e)
        {
            LoginFrom loginFrom = new LoginFrom();
            loginFrom.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string userId = txtUserId.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = "";

            if (rbFaculty.Checked)
            {
                role = "Faculty";
            }
            else if (rbStudent.Checked)
            {
                role = "Student";
            }
            else if (rbStaff.Checked)
            {
                role = "Staff";
            }

            // Input validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert user into the database
            try
            {
                SqlConnection conn = DatabaseConnection.GetConnection();
                
                    conn.Open();
                    string query = $"INSERT INTO Users (UserID, Name, Email, Password, Role) VALUES ('{userId}', '{name}', '{email}', '{password}', '{role}')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                    
                        

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LoginFrom loginFrom = new LoginFrom();
                            loginFrom.Show();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
