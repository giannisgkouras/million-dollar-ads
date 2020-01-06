using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using FireSharp.Response;
using FireSharp.EventStreaming;
using FireSharp.Extensions;


namespace MillionDollarAds
{
    public partial class AddAdv : Form
    {
        public AddAdv()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "tLGlHxPJ5x9JSZSPoNKLnSCgmNake8kEP3KYZzta",
            BasePath = "https://ads1-d054d.firebaseio.com"
        };

        IFirebaseClient client;
                      

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
               
            }
            catch
            {
                MessageBox.Show("No Internet or Connection Porblem");
            }

            //Get Categories and set to combobox
            for (int i=1; i<5; i++)
            {
                FirebaseResponse  response = client.Get(@"categories/"+i);
                Category category = new Category();
                category = response.ResultAs<Category>();
                comboBox1.Items.Add(category.Title);
            }
            
            
        }

        int id_count = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) &&
                string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(textBox3.Text) &&
                string.IsNullOrWhiteSpace(textBox4.Text))

            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }


            
            if (LoginForm.getUsername == "")
            {
                button1.Enabled = false;
                MessageBox.Show("Πρέπει να συνδεθείτε!");
            }
            else
            {

                FirebaseResponse response = client.Get(@"Users/"+LoginForm.getUsername);

                User resUser = new User();
                resUser = response.ResultAs<User>();

                Product product = new Product()
                {
                    Title= textBox1.Text,
                    Desc = textBox2.Text,
                    Image = textBox3.Text,
                    Price = textBox4.Text,
                    Id = resUser.LastId.ToString(),
                };

            
                SetResponse setToUserAds = client.Set(@"userAds/" +LoginForm.getUsername+"/"+resUser.LastId, product);
                SetResponse setToSubCategories = client.Set(@"subCategories/"+comboBox1.Items[comboBox1.SelectedIndex].ToString()+"/" + LoginForm.getUsername + "/" + resUser.LastId, product);
                
                resUser.LastId++;
                SetResponse updateLastId = client.Set(@"Users/"+LoginForm.getUsername, resUser );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
