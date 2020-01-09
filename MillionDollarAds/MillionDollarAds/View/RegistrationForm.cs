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

namespace MillionDollarAds
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
            BasePath = "https://ads1-d054d.firebaseio.com"
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

       


        private string createUserID()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTbox.Text) &&
               string.IsNullOrWhiteSpace(emailTbox.Text) &&
               string.IsNullOrWhiteSpace(passwordTbox.Text) &&
               string.IsNullOrWhiteSpace(cPassordTbox.Text) &&
               string.IsNullOrWhiteSpace(phoneText.Text))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }

            if (passwordTbox.Text != cPassordTbox.Text)  {
                MessageBox.Show("Οι κωδικοί πρόσβασης δεν ταιριάζουν.");
                return;
            }

            // Eλεγχος αν υπαρχει ηδη το ονομα ή το email
           
            /*
            FirebaseResponse response; 
            if(client.Get(@"Users/" + usernameTbox).StatusCode.Equals())
            {

            }

            User dbUser = response.ResultAs<User>();
            */

            

            User user = new User()
            {
                Username = usernameTbox.Text,
                Email = emailTbox.Text,
                Password = passwordTbox.Text,
                Phone = phoneText.Text,
                TotalAds = 0,
                Id = createUserID(),
            };

            SetResponse set = client.Set(@"MillionDollarAds/Users/" + usernameTbox.Text, user);
            
            MessageBox.Show("Η εγγραφή ολοκληρώθηκε!");
        }
    }
}
