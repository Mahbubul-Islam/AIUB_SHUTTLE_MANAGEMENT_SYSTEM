using NewInterior.Database;
using NewInterior.userComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewInterior.Views
{
    public partial class Edit_Profile : Form
    {
        string userId;
        string name;
        string email;
        string phone;
        string gender;
        string Address;
        string Nationality;
        string BloodGroup;
        string Dob;
        public Edit_Profile(string UserID)
        {
            InitializeComponent();
            userId = UserID;
        }

        private void addressLabel_Click(object sender, EventArgs e)
        {

        }

        private void streetNameOrNumberTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void houseOrBuildingOrFlatNumberTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void cityOrAreaNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void postalCodeTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void houseOrBuildingOrFlatNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void phoneNumberTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void phoneNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Users SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber, Gender = @Gender, " +
                                   "Address = @Address, Nationality = @Nationality, BloodGroup = @BloodGroup, Dob = @Dob WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Address", Address); // Fix: Changed 'address' to 'Address'
                        cmd.Parameters.AddWithValue("@Nationality", Nationality); // Fix: Changed 'nationality' to 'Nationality'
                        cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup); // Fix: Changed 'bloodGroup' to 'BloodGroup'
                        cmd.Parameters.AddWithValue("@Dob", Dob); // Fix: Changed 'dob' to 'Dob'

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            formManageAccount manage = new formManageAccount();
                            manage.Show();
                        }
                        else
                        {
                            MessageBox.Show("Profile update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            name = txtname.Text.Trim();
            email = txtemail.Text.Trim();
            phone = txtphonenumber.Text.Trim();
            Address = txtaddress.Text.Trim(); // Fix: Changed 'address' to 'Address'
            Nationality = txtnationality.Text.Trim(); // Fix: Changed 'nationality' to 'Nationality'
            BloodGroup = txtbloodgroup.Text.Trim(); // Fix: Changed 'bloodGroup' to 'BloodGroup'
            Dob = dtpDob.Value.ToString("yyyy-MM-dd"); // Fix: Changed 'dob' to 'Dob' and formatted date

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(Address) || string.IsNullOrWhiteSpace(Nationality) || string.IsNullOrWhiteSpace(BloodGroup))
            {
                return false;
            }

            if (rbmale.Checked)
            {
                gender = rbmale.Text.Trim();
            }
            else if (rbfemale.Checked)
            {
                gender = rbfemale.Text.Trim();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
