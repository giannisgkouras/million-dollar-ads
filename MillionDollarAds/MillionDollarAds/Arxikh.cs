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
            get { return homePage1; }
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

        private void button2_Click(object sender, EventArgs e)
        {
  /*
            string title = null;
            string desc = null;

            if (listView1.SelectedItems.Count >0 )
            {
                title = listView1.SelectedItems[0].SubItems[0].Text;
                desc = listView1.SelectedItems[0].SubItems[1].Text;

                label1.Text = title + "  " + desc;
            }
            else
            {
                MessageBox.Show("Choose an ad");
            }*/
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

            showAllAds.Columns.Add("Title", 100);
            showAllAds.Columns.Add("Description", 200);
            showAllAds.Columns.Add("Price", 100);
            showAllAds.Columns.Add("Type", 100);
            showAllAds.Columns.Add("Date", 100);

            ListViewItem itm;

            foreach (Product products in allProducts)
            {
                Invoke((MethodInvoker)delegate
                {
                    itm = new ListViewItem(new string[] { products.Title, products.Desc, products.Price, products.Type, products.Date, });
                    showAllAds.Items.Add(itm);
                });
            }
        }
    }
}
