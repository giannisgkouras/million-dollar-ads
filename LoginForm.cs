using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Ads
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "tLGlHxPJ5x9JSZSPoNKLnSCgmNake8kEP3KYZzta",
            BasePath = "https://ads1-d054d.firebaseio.com/"
        };

        IFirebaseClient client;

        private void LoginForm_Load(object sender, EventArgs e) 
        {
            try 
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("No Internet or Connection Porblem");
            }

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
        }

        private void usernameTbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordTbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTbox.Text) &&               
               string.IsNullOrWhiteSpace(passwordTbox.Text)
               )
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }

            FirebaseResponse res = client.Get(@"Users/" + usernameTbox.Text);

            // database result
            User resUser = res.ResultAs<User>();

            User currentUser = new User()
            {
                Username = usernameTbox.Text,
                Password = passwordTbox.Text
            };

            if (User.IsEqual(resUser, currentUser))
            {
                MessageBox.Show("Επιτυχής σύνδεση!!");
                //TODO: τι γίνεται όταν συνδεθεί 
            }
            else
            {
                User.ShowError();
            }

        }
    }
}
