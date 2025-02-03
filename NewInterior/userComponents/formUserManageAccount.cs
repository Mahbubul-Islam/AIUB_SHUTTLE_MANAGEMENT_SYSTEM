using NewInterior.Database;
using NewInterior.Login;
using NewInterior.Views;
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



namespace NewInterior.userComponents
{

    public partial class formUserManageAccount : UserControl
    {
        string userid;
        string _nameValue;
        string _emailValue;
        string _phoneValue;
        string _GenderValue;

        public formUserManageAccount(string UserID)
        {
            InitializeComponent();
            this.userid = UserID;
            LoadUserProfile(); // Fetch user data
            showProfile();     // Update UI with user data
        }
        private void LoadUserProfile()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Name, Email, PhoneNumber, Nationality,BloodGroup, Address, Gender, Dob, Role FROM Users WHERE UserID = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _nameValue = reader["Name"].ToString();
                                _emailValue = reader["Email"].ToString();
                                _phoneValue = reader["PhoneNumber"].ToString();
                                _GenderValue = reader["Gender"].ToString();
                               
                            }
                        }
                    }
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user profile: " + ex.Message);
            }
        }

        public void showProfile()
        {
            idValue.Text = userid;
            nameValue.Text = _nameValue;
            emailValue.Text = _emailValue;
            phoneValue.Text = _phoneValue;         
            GenderValue.Text = _GenderValue;
           
        }
   



        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Profile edit_profile = new Edit_Profile(this.userid);
            edit_profile.Show();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void lblResetpassword_Click(object sender, EventArgs e)
        {
            Reset_Password reset_Password = new Reset_Password(userid);
            reset_Password.Show();
        }

        // Inside the namespace NewInterior.userComponents
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete Your Account?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqlConnection conn = null;
                try
                {
                    conn = DatabaseConnection.GetConnection();
                    conn.Open();
                    string query = "DELETE FROM Users WHERE UserID = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                            this.Visible = false;
                            LoginFrom login = new LoginFrom();
                            login.Show();
                            this.ParentForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
