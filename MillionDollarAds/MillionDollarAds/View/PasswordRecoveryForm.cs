using MillionDollarAds.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionDollarAds.View
{
    public partial class PasswordRecoveryForm : Form
    {
        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            PasswordRecoveryHandler passwordRecoveryHandler = new PasswordRecoveryHandler(usernameTextBox.Text, emailTextBox.Text);

            bool accExists = false;
            accExists = passwordRecoveryHandler.checkAccount();

            if (accExists)
            {
                requestBtn.BackColor = Color.Green;
                requestBtn.Text = "OK";
                oldPasswordTextBox.Visible = true;
                newpasswordTextBox.Visible = true;
                changePasswordBtn.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else
            {
                MessageBox.Show("Username and email don't match!");
            }
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            Database.changeUserPassoword(usernameTextBox.Text, emailTextBox.Text, oldPasswordTextBox.Text, newpasswordTextBox.Text);
            MessageBox.Show("Your password updated successfully!!");
            this.Close();
            
        }
    }
}
