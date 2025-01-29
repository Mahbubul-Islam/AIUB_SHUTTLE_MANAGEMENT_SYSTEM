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

namespace NewInterior
{
    public partial class Form1 : Form
    {
        string _userId;
        formHome home = new formHome();
        
        formAboutUs aboutUs = new formAboutUs();
        formNotification notification = new formNotification();
        formManageAccount manageAccount = new formManageAccount();
        formMyBooking myBooking = new formMyBooking();
        formShuttleSchedule shuttleSchedule = new formShuttleSchedule();
        formBookSeat bookSeat = new formBookSeat();

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
            addUserControl(home);
            _userId = userId;
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
            addUserControl(home);
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            addUserControl(home);
        }

        private void homePannel_Click(object sender, EventArgs e)
        {
            addUserControl(home);
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
            addUserControl(bookSeat);
        }

        private void bookaseatLabel_Click(object sender, EventArgs e)
        {
            addUserControl(bookSeat);
        }

        private void bookaseatPanel_Click(object sender, EventArgs e)
        {
            addUserControl(bookSeat);
        }

        private void picboxMyBooking_Click(object sender, EventArgs e)
        {
            addUserControl(myBooking);
        }

        private void lblMyBooking_Click(object sender, EventArgs e)
        {
            addUserControl(myBooking);
        }

        private void pnlMyBooking_Click(object sender, EventArgs e)
        {
            addUserControl(myBooking);
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
            addUserControl(manageAccount);
        }

        private void lblManageAccount_Click(object sender, EventArgs e)
        {
            addUserControl(manageAccount);
        }

        private void pnlManageAccont_Click(object sender, EventArgs e)
        {
            addUserControl(manageAccount);
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
    }
}
