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
        //Category category = new Category();
        List<Category> categoriesList = new List<Category>();
        List<Category> subcategoriesList = new List<Category>();

        int categoryCount = 1;

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


            
            response = client.Get(@"MillionDollarAds/categories/");            
            List<Category> categories = response.ResultAs<List<Category>>();            
            int numberOfCategories = categories.Count;

            
            /*
            FirebaseResponse response2 = client.Get(@"MillionDollarAds/AdsByCategory/");
            List<Product> userAds = response2.ResultAs<List<Product>>();
            int numberOfUserAds = userAds.Count;
            */
            

            //Get Categories and set to combobox
            for (int i=1; i<numberOfCategories; i++)
            {
                if (categories[i].HasFather == 0)
                {
                    categoryCB.Items.Add(categories[i].Title);
                    categoriesList.Add(new Category()
                    {
                        HasFather = categories[i].HasFather,
                        Id = categories[i].Id,
                        Title = categories[i].Title,
                    });
                }

                if(categories[i].HasFather != 0)
                {
                    subcategoriesList.Add(new Category() { 
                        HasFather = categories[i].HasFather,
                        Id = categories[i].Id,
                        Title = categories[i].Title,
                    });
                }
            }
        }
        private string[] getSubCategoriesByFather(int fatherId)
        {
            return subcategoriesList.Where(sub => sub.HasFather == fatherId).Select(s => s.Title).ToArray();
        }

        private int[] getSubCategoryIdByName(string title)
        {
            return subcategoriesList.Where(sub => sub.Title == title).Select(c => c.Id).ToArray();
        }
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

                if (categoryCB.SelectedItem == null)
                {
                    MessageBox.Show("Πρέπει να επιλέξετε κατηγορία");
                }

                if (categoryCB.SelectedItem != null && subcategoryCB.SelectedItem == null)
                {
                    MessageBox.Show("Πρέπει να επιλέξετε υποκατηγορία");
                }               

                else {
                    int selectedCategoryId = getSubCategoryIdByName(subcategoryCB.SelectedItem.ToString())[0];
                    

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
                        Owner = Arxikh.user,
                        Title = textBox1.Text,
                        Desc = textBox2.Text,
                        Image = textBox3.Text,
                        Price = textBox4.Text,
                        Id = Arxikh.user.TotalAds+1,
                        CategoryId = selectedCategoryId,
                        Type = type,
                        Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),                        
                    };

                    //Γράφει στην βάση την αγγελία του χρήστη [userAds/username/ProductId=>product]
                    SetResponse setToUserAds = client.Set(@"MillionDollarAds/userAds/" + Arxikh.user.Username + "/"+ product.Id, product);

                    //
                    SetResponse setToAdsByCategory = client.Set(@"MillionDollarAds/AdsByCategory/" + product.CategoryId+"/"+Properties.Settings.Default.catCounter, product);

                    Arxikh.user.TotalAds++;
                    SetResponse updateLastId = client.Set(@"MillionDollarAds/Users/" + Arxikh.user.Username, Arxikh.user);
                    Properties.Settings.Default.catCounter++;
                    Properties.Settings.Default.Save();
                    
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
            int fatherId = categoriesList[categoryCB.SelectedIndex].Id;
            foreach (string title in getSubCategoriesByFather(fatherId))
            {
                if (title != "" || title != null)
                {
                    this.subcategoryCB.Items.Add(title);
                    subcategorylabel.Visible = true;
                    subcategoryCB.Visible = true;
                }
                else {
                    subcategorylabel.Visible = false;
                    subcategoryCB.Visible = false;                
                    this.subcategoryCB.Items.Add(categoriesList[categoryCB.SelectedIndex].Title);
                }

            }
        }
    }
}
