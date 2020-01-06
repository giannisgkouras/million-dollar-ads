using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionDollarAds
{
    public partial class Arxikh : Form
    {
        public Arxikh()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            new LoginForm(this).Show();
            
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
           
        }

        private void buttonnn_Click(object sender, EventArgs e)
        {
            redPanel.Height = exp2Button.Height;
            redPanel.Top = exp2Button.Top;
            exp2Page1.BringToFront();
            new AddAdv().Show();

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            
            redPanel.Height = homeButton.Height;
            redPanel.Top = homeButton.Top;
            homePage1.BringToFront();
            //homePage1.homeLabel.Text = "okeeeeee";  in order to work should make homeLabel public from Homepage.cs
        }

       
        public Button getLoginButton
        {
            get { return loginButton; }
        }

        public Button getRegisterButton
        {
            get { return signupButton; }
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Arxikh_Load(object sender, EventArgs e)
        {
          
        }

        
    }
}
