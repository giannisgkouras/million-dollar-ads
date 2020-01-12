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
using Lucene.Net.Documents;
using MillionDollarAds.Model;

namespace MillionDollarAds
{
    public partial class Arxikh : Form
    {
        public static User user = null;
        public static ViewHistory viewhistory = null;

        List<Category> categories;
        List<Category> subCategories;
        public int selectedCategoryId = 0;
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
            homePage1.Initialize();
            homePage1.BringToFront();
        }
        public int getCategoryId
        {
            get { return selectedCategoryId ; }
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

        public Button getViewHistoryButton
        {
            get { return viewHistoryButton; }
        }

        public CreateAdPage getCreateAdPage
        {
            get { return createAdPage1; }
        }

        public ViewHistoryPage getViewHistoryPage
        {
            get {
                viewHistoryPage1.Initialize();
                return viewHistoryPage1; }
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
            viewHistoryButton.Visible = false;
        }

        private void homePage1_Load(object sender, EventArgs e)
        {
            refreshAllAds();
            categories = Database.getAllCategories();

            foreach (Category category in categories)
            {
                if(category.HasFather == 0)
                {
                    switch (category.Id)
                    {
                        
                        case 1:
                            category1.Text = category.Title;
                            break;

                        case 2:
                            category2.Text = category.Title;
                            break;

                        case 3:
                            category3.Text = category.Title;
                            break;

                        default: 
                            break;
                    }                    
                }
            }           
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
        public void refreshAllAdsByCategory(int fathersId)
        {
            ListView listView = homePage1.getListViewHomePage;
            listView.Items.Clear();
            listView.Columns.Clear();

            listView.View = System.Windows.Forms.View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;

            var list = new List<Product>();

            List<Product> allProducts = Database.getAllProductsByCategory(fathersId);

            listView.Columns.Add("Title", 100);
            listView.Columns.Add("Description", 200);
            listView.Columns.Add("Price", 100);
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Date", 100);

            ListViewItem itm;

            foreach (Product products in allProducts)
            {
                Invoke((MethodInvoker)delegate
                {
                    itm = new ListViewItem(new string[] { products.Title, products.Desc, products.Price, products.Type, products.Date, });
                    listView.Items.Add(itm);
                });
            }
        }

        public void refreshAllAdsBySubCategory(int categoryId)
        {
            ListView listView = homePage1.getListViewHomePage;
            listView.Items.Clear();
            listView.Columns.Clear();

            listView.View = System.Windows.Forms.View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;

            var list = new List<Product>();

            List<Product> allProducts = Database.getAllProductsBySubCategory(categoryId);

            listView.Columns.Add("Title", 100);
            listView.Columns.Add("Description", 200);
            listView.Columns.Add("Price", 100);
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Date", 100);

            ListViewItem itm;

            foreach (Product products in allProducts)
            {
                Invoke((MethodInvoker)delegate
                {
                    itm = new ListViewItem(new string[] { products.Title, products.Desc, products.Price, products.Type, products.Date, });
                    listView.Items.Add(itm);
                });
            }
        }

        public void refreshViewHistory()
        {
            ListView showViewHistoryListView = viewHistoryPage1.getListViewHistoryPage;
            showViewHistoryListView.Items.Clear();
            showViewHistoryListView.Columns.Clear();

            showViewHistoryListView.View = System.Windows.Forms.View.Details;
            showViewHistoryListView.GridLines = true;
            showViewHistoryListView.FullRowSelect = true;

            var list = new List<Product>();

            List<Product> allProducts = Database.getProductsInViewHistoryOfLoggedUser();


            showViewHistoryListView.Columns.Add("Id", 25);
            showViewHistoryListView.Columns.Add("Title", 100);
            showViewHistoryListView.Columns.Add("Description", 200);
            showViewHistoryListView.Columns.Add("Price", 50);
            showViewHistoryListView.Columns.Add("Type", 50);
            showViewHistoryListView.Columns.Add("Category", 100);
            showViewHistoryListView.Columns.Add("Date", 100);

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
                        if (products.CategoryId == categoriesArray[i].Id)
                        {
                            category = categoriesArray[i];
                        }
                    }
                    Console.WriteLine(products.Id);
                    itm = new ListViewItem(new string[] { products.Id.ToString(), products.Title, products.Desc, products.Price, products.Type, category.Title, products.Date, });
                    showViewHistoryListView.Items.Add(itm);
                });
            }
        }

        private void category1_Click(object sender, EventArgs e)
        {
            selectedCategoryId = Database.getCategoryIdByName(category1.Text);
            category1.Location = new Point(20, 175);
            category2.Location = new Point(20, 371);
            category3.Location = new Point(20, 424);
            sub1.Location = new Point(20, 228);
            sub2.Location = new Point(20, 281);
            sub1.Visible = true;
            sub2.Visible = true;
            redPanel.Height = category1.Height;
            redPanel.Top = category1.Top;
            
            subCategories = Database.getSubCategoriesByFather(Database.getCategoryIdByName(category1.Text));
            refreshAllAdsByCategory(Database.getCategoryIdByName(category1.Text));        
            homePage1.BringToFront();


     
            for(int i=0; i<subCategories.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        sub1.Text = subCategories[i].Title;
                        break;
                    case 1:
                        sub2.Text = subCategories[i].Title;
                        break;
                    default:
                        break;                          
                }
            }

        }

        private void category2_Click(object sender, EventArgs e)
        {
            selectedCategoryId = Database.getCategoryIdByName(category2.Text);
            category2.Location = new Point(20, 175);
            category1.Location = new Point(20, 371);
            category3.Location = new Point(20, 424);
            sub1.Location = new Point(20, 228);
            sub2.Location = new Point(20, 281);
            sub1.Visible = true;
            sub2.Visible = true;
            redPanel.Height = category2.Height;
            redPanel.Top = category2.Top;
            
            subCategories = Database.getSubCategoriesByFather(Database.getCategoryIdByName(category2.Text));
            refreshAllAdsByCategory(Database.getCategoryIdByName(category2.Text));
            homePage1.BringToFront();




            for (int i = 0; i < subCategories.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        sub1.Text = subCategories[i].Title;
                        break;
                    case 1:
                        sub2.Text = subCategories[i].Title;
                        break;
                    default:
                        break;
                }
            }
        }

        private void category3_Click(object sender, EventArgs e)
        {
            selectedCategoryId = Database.getCategoryIdByName(category3.Text);

            category3.Location = new Point(20, 175);
            category1.Location = new Point(20, 371);
            category2.Location = new Point(20, 424);

            sub1.Location = new Point(20, 228);
            sub2.Location = new Point(20, 281);
            sub1.Visible = true;
            sub2.Visible = true;
            redPanel.Height = category3.Height;
            redPanel.Top = category3.Top;

            subCategories = Database.getSubCategoriesByFather(Database.getCategoryIdByName(category3.Text));
            refreshAllAdsByCategory(Database.getCategoryIdByName(category3.Text));
            homePage1.BringToFront();



            for (int i = 0; i < subCategories.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        sub1.Text = subCategories[i].Title;
                        break;
                    case 1:
                        sub2.Text = subCategories[i].Title;
                        break;
                    default:
                        break;
                }
            }

        }

        private void sub1_Click_1(object sender, EventArgs e)
        {
            //selectedCategoryId = Database.getCategoryIdByName(sub1.Text);
            redPanel.Height = sub1.Height;
            redPanel.Top = sub1.Top;
            //subCategories = Database.getSubCategoriesByFather(selectedCategoryId);
            int id = Database.getCategoryIdByName(sub1.Text);
            refreshAllAdsBySubCategory(id);
            homePage1.BringToFront();
        }

        private void sub2_Click_1(object sender, EventArgs e)
        {
            // selectedCategoryId = Database.getCategoryIdByName(sub2.Text);
            redPanel.Height = sub2.Height;
            redPanel.Top = sub2.Top;
            // subCategories = Database.getSubCategoriesByFather(selectedCategoryId);
            int id = Database.getCategoryIdByName(sub2.Text);
            refreshAllAdsBySubCategory(id);
            homePage1.BringToFront();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            refreshAllAds();
            redPanel.Height = homeButton.Height;
            redPanel.Top = homeButton.Top;
            homePage1.Initialize();
            homePage1.BringToFront();

            SearchHandler.createIndex();

            List<Document> list = null;
            list = SearchHandler.searchViaTextInTitle(searchTextBox.Text, homePage1.getListViewHomePage);

            List<Category> categories = Database.getAllCategories();
            Category[] categoriesArray = categories.ToArray();
            Category category = null;

            if (list == null)
                MessageBox.Show("No result found.");
            else
            {
                foreach (Document doc in list)
                {

                    Product products = Database.getAdbyId(doc.GetField("ad_id").StringValue);

                    for (int i = 0; i < categories.Count; i++)
                    {
                        if (products.CategoryId == categoriesArray[i].Id)
                        {
                            category = categoriesArray[i];
                        }
                    }

                    ListViewItem itm;
                    itm = new ListViewItem(new string[] { products.Id.ToString(), products.Title, products.Desc, products.Price, products.Type, category.Title, products.Date, });
                    //itm = new ListViewItem(new string[] { doc.GetField("ad_id").StringValue, doc.GetField("ad_title").StringValue });
                    homePage1.getListViewHomePage.Items.Add(itm);
                    Console.WriteLine(doc.GetField("ad_id").StringValue + "     aaaaaaaaaa      " + doc.GetField("ad_title").StringValue);
                }
            }
            homePage1.Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshViewHistory();
            viewHistoryPage1.Initialize();
            redPanel.Height = viewHistoryButton.Height;
            redPanel.Top = viewHistoryButton.Top;
            viewHistoryPage1.BringToFront();
        }

    }
}
