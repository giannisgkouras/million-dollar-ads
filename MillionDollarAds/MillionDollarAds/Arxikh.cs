using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MillionDollarAds.View;

using MillionDollarAds.Control;

namespace MillionDollarAds
{
    public partial class Arxikh : Form
    {
        public static User user = null;
        public Arxikh()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginPage1.BringToFront();
            
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            signUpPage1.BringToFront();
           
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            refreshAllAds();
            redPanel.Height = homeButton.Height;
            redPanel.Top = homeButton.Top;
            homePage1.BringToFront();
        }

       
        public Button getLoginButton
        {
            get { return loginButton; }
        }

        public Button getRegisterButton
        {
            get { return signupButton; }
        }

        public HomePage getHomePage
        {
            get {
                homePage1.Initialize(); 
                return homePage1; }
        }

        public LoginPage getLoginPage
        {
            get { return loginPage1; }
        }

        public SignUpPage getSignUpPage
        {
            get { return signUpPage1; }
        }

        public Button getCreateAdButton
        {
            get { return createAdButton; }
        }

        public CreateAdPage getCreateAdPage
        {
            get { return createAdPage1; }
        }

        private void exp2Button_Click(object sender, EventArgs e)
        {
            redPanel.Height = exp2Button.Height;
            redPanel.Top = exp2Button.Top;
            exp2Page1.BringToFront();
        }

        private void createAdButton_Click(object sender, EventArgs e)
        {
            redPanel.Height = createAdButton.Height;
            redPanel.Top = createAdButton.Top;
            createAdPage1.BringToFront();
        }

        private void Arxikh_Load(object sender, EventArgs e)
        {
            createAdButton.Visible = false;
        }

        private void homePage1_Load(object sender, EventArgs e)
        {
            refreshAllAds();
        }

        public void refreshAllAds()
        {
            ListView showAllAds = homePage1.getListViewHomePage;
            showAllAds.Items.Clear();
            showAllAds.Columns.Clear();

            showAllAds.View = System.Windows.Forms.View.Details;
            showAllAds.GridLines = true;
            showAllAds.FullRowSelect = true;

            var list = new List<Product>();

            List<Product> allProducts = Database.getAllProducts();

            showAllAds.Columns.Add("Id", 25);
            showAllAds.Columns.Add("Title", 100);
            showAllAds.Columns.Add("Description", 200);
            showAllAds.Columns.Add("Price", 50);
            showAllAds.Columns.Add("Type", 50);
            showAllAds.Columns.Add("Category", 100);
            showAllAds.Columns.Add("Date", 100);

            ListViewItem itm;

            List<Category> categories = Database.getAllCategories();
            Category[] categoriesArray = categories.ToArray();
            Category category = null;

            


            foreach (Product products in allProducts)
            {
                Invoke((MethodInvoker)delegate
                {
                    for (int i = 0; i < categories.Count; i++)
                    {
                        if ( products.CategoryId == categoriesArray[i].Id)
                        {
                            category = categoriesArray[i];
                        }
                    }

                    itm = new ListViewItem(new string[] { products.Id.ToString(),products.Title, products.Desc, products.Price, products.Type, category.Title, products.Date, });
                    showAllAds.Items.Add(itm);
                });
            }
        }
    }
}
