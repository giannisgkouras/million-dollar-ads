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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "tLGlHxPJ5x9JSZSPoNKLnSCgmNake8kEP3KYZzta",
            BasePath = "https://ads1-d054d.firebaseio.com/"
        };

        IFirebaseClient client;

        private void RegistrationForm_Load(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(usernameTbox.Text) &&
               string.IsNullOrWhiteSpace(emailTbox.Text) &&
               string.IsNullOrWhiteSpace(passwordTbox.Text) &&
               string.IsNullOrWhiteSpace(cPassordTbox.Text))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }

            if (passwordTbox.Text != cPassordTbox.Text)  {
                MessageBox.Show("Οι κωδικοί πρόσβασης δεν ταιριάζουν.");
                return;
            }

            //TODO: ελεγχος αν υπαρχει ηδη το ονομα ή το email

            User user = new User()
            {
                Username = usernameTbox.Text,
                Email = emailTbox.Text,
                Password = passwordTbox.Text,                 
            };

            SetResponse set = client.Set(@"Users/" + usernameTbox.Text+"123", user);
            
            MessageBox.Show("Η εγγραφή ολοκληρώθηκε!");
        }
    }
}
