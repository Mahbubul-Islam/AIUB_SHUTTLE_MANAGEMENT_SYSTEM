using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewInterior.userComponents;
using System.Windows.Forms;
using NewInterior.Database;
using System.Data.SqlClient;
using NewInterior.Login;
using NewInterior.Views;

namespace NewInterior
{
    public partial class Form1 : Form
    {
        string _userId;
        string _userRole;
        formHome home = new formHome();
        
        formAboutUs aboutUs = new formAboutUs();
        formNotification notification = new formNotification();
        formManageAccount manageAccount = new formManageAccount();
        
        formShuttleSchedule shuttleSchedule = new formShuttleSchedule();
        
        formDashboard formDashboard = new formDashboard();  
       

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDisplay.Controls.Clear();
            pnlDisplay.Controls.Add(userControl);
            userControl.BringToFront();

        }
        public Form1(string userId)
        {
            InitializeComponent();
            sidebar.Width = 43; // Set to collapsed width
            sidebarExpand = false; // Sidebar is collapsed by default
            usertoolsContainer.Height = 55;
            sidebarExpand = false;
            settingsExpand = false;
            _userId = userId;
            GetUserRole();
            if (_userRole == "Admin")
            {
                addUserControl(formDashboard);
                formDashboard.upOverAllData();
            }
            else
            {
                addUserControl(home);
            }
            
            
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool usertoolsExpand = false;
        private void usertoolsTransition_Tick(object sender, EventArgs e)
        {
            if (usertoolsExpand == false)
            {
                usertoolsContainer.Height += 10;
                if (usertoolsContainer.Height >= 277)
                {
                    usertoolsTransition.Stop();
                    usertoolsExpand = true;
                }
            }
            else
            {
                usertoolsContainer.Height -= 10;
                if (usertoolsContainer.Height <= 55)
                {
                    usertoolsTransition.Stop();
                    usertoolsExpand = false;
                }
            }
        }

        private void usertoolsDropdown_Click(object sender, EventArgs e)
        {
            usertoolsTransition.Start();
        }

        private void usertoolsLabel_Click(object sender, EventArgs e)
        {
            usertoolsTransition.Start();
        }

        private void usertoolsIcon_Click(object sender, EventArgs e)
        {
            usertoolsTransition.Start();
        }

        private void usertoolsPanel_Click(object sender, EventArgs e)
        {
            usertoolsTransition.Start();
        }

        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand == true)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 43)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    homePannel.Width = sidebar.Width;
                    usertoolsPanel.Width = sidebar.Width;
                    profilePannel.Width = sidebar.Width;
                    pnlAboutUs.Width = sidebar.Width;
                    settingsPanel.Width = sidebar.Width;
                    usertoolsContainer.Width = sidebar.Width;
                    settingsContainer.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 250)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    homePannel.Width = sidebar.Width;
                    usertoolsPanel.Width = sidebar.Width;
                    profilePannel.Width = sidebar.Width;
                    pnlAboutUs.Width = sidebar.Width;
                    settingsPanel.Width = sidebar.Width;
                    usertoolsContainer.Width = sidebar.Width;
                    settingsContainer.Width = sidebar.Width;
                }

            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        bool settingsExpand = false;

        private void settingsTransition_Tick(object sender, EventArgs e)
        {
            if (settingsExpand == false)
            {
                settingsContainer.Height += 10;
                if (settingsContainer.Height >= 156)
                {
                    settingsTransition.Stop();
                    settingsExpand = true;
                }
            }
            else
            {
                settingsContainer.Height -= 10;
                if (settingsContainer.Height <= 55)
                {
                    settingsTransition.Stop();
                    settingsExpand = false;
                }
            }
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();
        }

        private void settingsDropdown_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();
        }

        private void settingsPanel_Click(object sender, EventArgs e)
        {
            settingsTransition.Start();
        }

        private void picboxHome_Click(object sender, EventArgs e)
        {
            if (_userRole == "Admin")
            {
                addUserControl(formDashboard);
                formDashboard.upOverAllData();
            }
            else
            {
                addUserControl(home);
            }
            //addUserControl(home);
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            if(_userRole == "Admin")
            {
                addUserControl(formDashboard);
                formDashboard.upOverAllData();
            }
            else
            {
                addUserControl(home);
            }
            //addUserControl(home);
        }

        private void homePannel_Click(object sender, EventArgs e)
        {
            if (_userRole == "Admin")
            {
                addUserControl(formDashboard);
                formDashboard.upOverAllData();
            }
            else
            {
                addUserControl(home);
            }
            //addUserControl(home);
        }

        private void picboxProfile_Click(object sender, EventArgs e)
        {
            formProfile profile = new formProfile(_userId);
            addUserControl(profile);
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            formProfile profile = new formProfile(_userId);
            addUserControl(profile);
        }

        private void profilePannel_Click(object sender, EventArgs e)
        {
            formProfile profile = new formProfile(_userId);
            addUserControl(profile);
        }

        private void shuttlescheduleIcon_Click(object sender, EventArgs e)
        {
            addUserControl(shuttleSchedule);
        }

        private void shuttlescheduleLabel_Click(object sender, EventArgs e)
        {
            addUserControl(shuttleSchedule);
        }

        private void shuttleschedulePanel_Click(object sender, EventArgs e)
        {
            addUserControl(shuttleSchedule);
        }

        private void bookaseatIcon_Click(object sender, EventArgs e)
        {
            formBookSeat seat = new formBookSeat(_userId);
            addUserControl(seat);
        }

        private void bookaseatLabel_Click(object sender, EventArgs e)
        {
            formBookSeat seat = new formBookSeat(_userId);
            addUserControl(seat);
        }

        private void bookaseatPanel_Click(object sender, EventArgs e)
        {
            formBookSeat seat = new formBookSeat(_userId);
            addUserControl(seat);
        }

        private void picboxMyBooking_Click(object sender, EventArgs e)
        {
            formMyBooking bookSeat = new formMyBooking(_userId);
            addUserControl(bookSeat);
        }

        private void lblMyBooking_Click(object sender, EventArgs e)
        {
            formMyBooking bookSeat = new formMyBooking(_userId);
            addUserControl(bookSeat);
        }

        private void pnlMyBooking_Click(object sender, EventArgs e)
        {
            formMyBooking bookSeat = new formMyBooking(_userId);
            addUserControl(bookSeat);
        }

        private void picboxNotification_Click(object sender, EventArgs e)
        {
            addUserControl(notification);
        }

        private void lblNotification_Click(object sender, EventArgs e)
        {
            addUserControl(notification);
        }

        private void pnlNotification_Click(object sender, EventArgs e)
        {
            addUserControl(notification);
        }

        private void picboxManageAccount_Click(object sender, EventArgs e)
        {
            if (_userRole == "Admin")
            {
                addUserControl(manageAccount);
            }
            else
            {
                formUserManageAccount userManageAccount = new formUserManageAccount(_userId);
                addUserControl(userManageAccount);
            }
        }

        private void lblManageAccount_Click(object sender, EventArgs e)
        {
            if (_userRole == "Admin")
            {
                addUserControl(manageAccount);
            }
            else
            {
                formUserManageAccount userManageAccount = new formUserManageAccount(_userId);
                addUserControl(userManageAccount);
            }
        }

        private void pnlManageAccont_Click(object sender, EventArgs e)
        {
            if (_userRole == "Admin")
            {
                addUserControl(manageAccount);
            }
            else
            {
                formUserManageAccount userManageAccount = new formUserManageAccount(_userId);
                addUserControl(userManageAccount);
            }
        }

        private void picboxAboutUs_Click(object sender, EventArgs e)
        {
            addUserControl(aboutUs);
        }

        private void lblAboutUS_Click(object sender, EventArgs e)
        {
            addUserControl(aboutUs);
        }

        private void pnlAboutUs_Click(object sender, EventArgs e)
        {
            addUserControl(aboutUs);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void GetUserRole()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Role FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId); // Add parameter to the query
                    object result = cmd.ExecuteScalar(); // ExecuteScalar returns the first column of the first row in the result set returned by the query
                    _userRole = result?.ToString(); // Null conditional operator
                }
            }
        }

        private void picboxLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginFrom login = new LoginFrom();
                login.Show();
                this.Hide();
            }
        }

        private void pnlLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginFrom login = new LoginFrom();
                login.Show();
                this.Hide();
            }
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginFrom login = new LoginFrom();
                login.Show();
                this.Hide();
            }
        }
    }
}
