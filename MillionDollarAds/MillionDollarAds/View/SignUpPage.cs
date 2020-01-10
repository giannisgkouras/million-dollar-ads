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

namespace MillionDollarAds.View
{
    public partial class SignUpPage : UserControl
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        Arxikh mainForm;
        public SignUpPage(Form callingForm)
        {
            mainForm = callingForm as Arxikh;
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPassTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;

            SignUpHandler signUpHandler = new SignUpHandler();
            int response = signUpHandler.completeRegistration(username, password, confirmPassword, phone,email);

            if ( response == 0)
            {
                MessageBox.Show("Fill all the fields.");
            }
            else if ( response == 1)
            {
                MessageBox.Show("Passwords don't match.");
            }
            else if ( response == 2)
            {
                MessageBox.Show("There is alreader an account with that username.");
            }
            else if ( response == 5)
            {
                MessageBox.Show("You have Signed Up :)");
                this.mainForm.getLoginPage.BringToFront();
            }
        }
    }
}
