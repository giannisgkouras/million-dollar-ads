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

        FirebaseResponse response;
        Category category = new Category();
        List<Category> categoriesList = new List<Category>();
        List<Category> subcategoriesList = new List<Category>();
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
            int counter = 0;
            
            for (int i=1; i<8; i++)
            {
                response = client.Get(@"categories/"+i);
                
                category = response.ResultAs<Category>();
                if (category.HasFather == "0")
                {
                    categoryCB.Items.Add(category.Title);
                    categoriesList.Add(new Category()
                    {
                        HasFather = category.HasFather,
                        Id = category.Id,
                        Title = category.Title,
                    });
                }

                if(category.HasFather != "0")
                {
                    subcategoriesList.Add(new Category() { 
                        HasFather = category.HasFather,
                        Id = category.Id,
                        Title = category.Title,
                    });
                }

               
            }


        }
        private string[] getSubCategoriesByFather(string fatherId)
        {
            return subcategoriesList.Where(sub => sub.HasFather == fatherId).Select(s => s.Title).ToArray();
        }

        int CategoryCounter = 1;

        private void button1_Click(object sender, EventArgs e)
        {

            string selectedCategory="";

            if (string.IsNullOrWhiteSpace(textBox1.Text) &&
                string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(textBox3.Text) &&
                string.IsNullOrWhiteSpace(textBox4.Text))

            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }


            
            if (Arxikh.user.Username == "")
            {
                button1.Enabled = false;
                MessageBox.Show("Πρέπει να συνδεθείτε!");
            }
            else
            {
                if (saleRB.Checked == false && demandRB.Checked == false)
                {
                    MessageBox.Show("Πρέπει να επιλέξετε τύπο αγγελίας");
                }

                if (categoryCB.SelectedItem == null )
                {
                    MessageBox.Show("Πρέπει να επιλέξετε κατηγορία");
                }

                if (categoryCB.SelectedItem != null && subcategoryCB.SelectedItem == null)
                {

                    MessageBox.Show("Πρέπει να επιλέξετε υποκατηγορία");

                }               

                else {               

                    FirebaseResponse response = client.Get(@"Users/"+ Arxikh.user.Username);                    

                    selectedCategory = subcategoryCB.Text;

                    string type= "";
                    if (saleRB.Checked)
                    {
                        type = saleRB.Text;
                    }
                    if (demandRB.Checked)
                    {
                        type = demandRB.Text;
                    }

                    Product product = new Product()
                    {
                        Owner = Arxikh.user.Username,
                        Title = textBox1.Text,
                        Desc = textBox2.Text,
                        Image = textBox3.Text,
                        Price = textBox4.Text,
                        Id = Arxikh.user.LastId.ToString(),
                        Type = type,
                        Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                        
                    };

                    //Γράφει στην βάση την αγγελία του χρήστη
                    SetResponse setToUserAds = client.Set(@"userAds/" + Arxikh.user.Username + "/"+ Arxikh.user.LastId, product);

                    //TODO κανει overwrite
                    SetResponse setToSCategories = client.Set(@"AdsByCategory/"+selectedCategory+"/", product);

                    Arxikh.user.LastId++;
                    SetResponse updateLastId = client.Set(@"Users/"+ Arxikh.user.Username, Arxikh.user);
                    
                }
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

        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcategoryCB.Items.Clear();
            string fatherId = categoriesList[categoryCB.SelectedIndex].Id;
            foreach (string title in getSubCategoriesByFather(fatherId))
            {
                if (title != "" || title != null)
                {
                    this.subcategoryCB.Items.Add(title);
                    subcategorylabel.Visible = true;
                    subcategoryCB.Visible = true;
                }
                else {
                    this.subcategoryCB.Items.Add(categoriesList[categoryCB.SelectedIndex].Title);
                    subcategorylabel.Visible = false;
                    subcategoryCB.Visible = false;                
                }

            }
        }
    }
}
