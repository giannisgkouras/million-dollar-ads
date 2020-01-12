using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MillionDollarAds.Control;
using System.Diagnostics;

namespace MillionDollarAds.View
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        Arxikh mainForm;

        public LoginPage(Form callingForm)
        {
            mainForm = callingForm as Arxikh;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            LoginHandler loginHandler = new LoginHandler(username, password);

            bool accExists = false;
            accExists =  loginHandler.checkAccount();

            if (accExists)
            {
                changeLogInAndRegisterButtons();

                mainForm.getCreateAdButton.Visible = true;
                mainForm.getMyAdsButton.Visible = true;
                mainForm.getViewHistoryButton.Visible = true;
                mainForm.getLogOutButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong username or password.");
            }
        }

        private void changeLogInAndRegisterButtons()
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";

            Button loginButton = this.mainForm.getLoginButton;
            Button registerButton = this.mainForm.getRegisterButton;

            registerButton.Visible = false;
            loginButton.Text = "Welcome " + Arxikh.user.Username;
            loginButton.Width = 175;
            loginButton.Location = new Point(loginButton.Location.X - 20, loginButton.Location.Y);
            loginButton.Enabled = false;
            this.mainForm.getHomePage.BringToFront();
        }

        private void passwordRecoveyPage1_Load(object sender, EventArgs e)
        {

        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            new PasswordRecoveryForm().ShowDialog();            
        }
    }
}
