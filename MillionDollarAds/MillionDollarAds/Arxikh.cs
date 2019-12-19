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
            new LoginForm().Show();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
        }
    }
}
