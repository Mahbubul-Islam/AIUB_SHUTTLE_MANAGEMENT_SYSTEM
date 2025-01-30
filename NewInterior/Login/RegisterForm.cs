using System;
using System.Data.SqlClient;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblHeading1_Click(object sender, EventArgs e)
        {

        }

        private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFaculty_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
