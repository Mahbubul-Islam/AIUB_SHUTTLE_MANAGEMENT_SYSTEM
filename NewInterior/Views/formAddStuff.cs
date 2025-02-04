using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NewInterior.Database;
using NewInterior.Models;
using NewInterior.userComponents;

namespace NewInterior.Views
{
    public partial class formAddStuff : Form
    {
        string _id;
        string _name;
        string _email;
        string _phone;
        string _address;
        string _bloodGroup;
        string _password;
        string _gender;
        string _dob;
        string _role = "Staff";
        string _Nationality;
        string userIdPattern = "^\\d{2}-\\d{2}-[1-3]$"; // XX-XX-X
        string adminId = "admin";
        private formManageAccount _parentForm;


        public formAddStuff(formManageAccount parentForm)
        {
            InitializeComponent();
            lblShowUserIDMsg.Text = "*Staff User ID usually looks like XX-XX-X";
            _parentForm = parentForm;
        }

        private void getValue()
        {
            _id = txtStaffId.Text.Trim();
            _name = txtStaffName.Text.Trim();
            _email = txtStaffEmail.Text.Trim();
            _phone = txtStaffPhoneNumber.Text.Trim();
            _address = txtAddress.Text.Trim();
            _bloodGroup = txtBloodGroup.Text.Trim();
            _password = txtPassword.Text.Trim();
            _gender = rbMale.Checked ? "Male" : "Female";
            _dob = dtpDob.Value.ToString("yyyy-MM-dd");
            _Nationality = txtNationality.Text.Trim();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(_id) || string.IsNullOrWhiteSpace(_name) ||
                string.IsNullOrWhiteSpace(_email) || string.IsNullOrWhiteSpace(_phone) ||
                string.IsNullOrWhiteSpace(_address) || string.IsNullOrWhiteSpace(_bloodGroup) ||
                string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_Nationality))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(_id, userIdPattern))
            {
                MessageBox.Show("Invalid Staff ID format. It should be XX-XX-X.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_email.Contains("@"))
            {
                MessageBox.Show("Invalid email format. Email must contain '@'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            getValue(); // Retrieve form values

            if (!ValidateForm()) return;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (UserID, Name, Email, Password, Role, Gender, Nationality, BloodGroup, Address, Dob, PhoneNumber) " +
                                   "VALUES (@UserID, @Name, @Email, @Password, @Role, @Gender, @Nationality, @BloodGroup, @Address, @Dob, @PhoneNumber)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _id);
                        cmd.Parameters.AddWithValue("@Name", _name);
                        cmd.Parameters.AddWithValue("@Email", _email);
                        cmd.Parameters.AddWithValue("@Password", _password);
                        cmd.Parameters.AddWithValue("@Role", _role);
                        cmd.Parameters.AddWithValue("@Gender", _gender);
                        cmd.Parameters.AddWithValue("@Nationality", _Nationality);
                        cmd.Parameters.AddWithValue("@BloodGroup", _bloodGroup);
                        cmd.Parameters.AddWithValue("@Address", _address);
                        cmd.Parameters.AddWithValue("@Dob", _dob);
                        cmd.Parameters.AddWithValue("@PhoneNumber", _phone);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _parentForm.ShowUser("Staff", "");
                            this.Close();
                            MakeNotification.AddNotification(adminId, "A user is added!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}