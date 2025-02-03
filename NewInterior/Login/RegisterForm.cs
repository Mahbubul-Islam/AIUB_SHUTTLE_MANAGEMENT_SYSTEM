using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NewInterior.Database;

namespace NewInterior.Login
{
    public partial class RegisterForm : Form
    {
        string name;
        string userId;
        string password;
        string confirmPassword;
        string email;
        string role;
        string userIdPattern;

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
            name = txtName.Text.Trim();
            userId = txtUserId.Text.Trim();
            password = txtPassword.Text.Trim();
            confirmPassword = txtConfirmPassword.Text.Trim();
            email = txtEmail.Text.Trim();
            role = "";

            if (rbFaculty.Checked)
            {
                role = "Faculty";
                userIdPattern = "^\\d{4}-\\d{3}-[1-3]$"; // XXXX-XXX-X
            }
            else if (rbStudent.Checked)
            {
                role = "Student";
                userIdPattern = "^\\d{2}-\\d{5}-[1-3]$"; // XX-XXXXX-X
            }
            else if (rbStaff.Checked)
            {
                role = "Staff";
                userIdPattern = "^\\d{2}-\\d{2}-[1-3]$"; // XX-XX-X
            }

            // Input validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(userId, userIdPattern))
            {
                MessageBox.Show("Invalid User ID format for " + role + ".", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Invalid email format. Email must contain '@'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Users (UserID, Name, Email, Password, Role) VALUES (@UserId, @Name, @Email, @Password, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);

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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = chkbShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !showPassword;
            txtConfirmPassword.UseSystemPasswordChar = !showPassword;
        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStudent.Checked)
            {
                lblShowUserIDMsg.Text = "*Student User ID usually looks like XX-XXXXX-X";
                txtUserId.MaxLength = 10;
            }
        }

        private void rbFaculty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFaculty.Checked)
            {
                lblShowUserIDMsg.Text = "*Faculty User ID usually looks like XXXX-XXX-X";
                txtUserId.MaxLength = 10;
            }
        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaff.Checked)
            {
                lblShowUserIDMsg.Text = "*Staff User ID usually looks like XX-XX-X";
                txtUserId.MaxLength = 7;
            }
        }
    }
}
