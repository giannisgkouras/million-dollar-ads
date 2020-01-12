using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MillionDollarAds.Control;

namespace MillionDollarAds.View
{
    public partial class ViewHistoryPage : UserControl
    {
        public ViewHistoryPage()
        {
            InitializeComponent();
        }

        private void ViewHistoryPage_Load(object sender, EventArgs e)
        {

        }

        public ListView getListViewHistoryPage
        {
            get { return listViewHistoryPage; }
        }

        public void Initialize()
        {
            showAdPanel.Visible = false;
            titleTextBox.ReadOnly = true;
            categoryTextBox.ReadOnly = true;
            priceTextBox.ReadOnly = true;
            descriptionTextBox.ReadOnly = true;
            ownerTextBox.ReadOnly = true;
            phoneTextBox.ReadOnly = true;
            emailTextBox.ReadOnly = true;
            typeTextBox.ReadOnly = true;
            dateTextBox.ReadOnly = true;

            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            priceTextBox.Text = "";
            typeTextBox.Text = "";
            categoryTextBox.Text = "";
            dateTextBox.Text = "";
            ownerTextBox.Text = "";
            phoneTextBox.Text = "";
            emailTextBox.Text = "";
        }

        private void showAdButton_Click(object sender, EventArgs e)
        {
            string id = null;
            

            if (listViewHistoryPage.SelectedItems.Count > 0)
            {
                id = listViewHistoryPage.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                MessageBox.Show("Choose an ad.");
                return;
            }
            showAdPanel.Visible = true;

            AdHandler handler = new AdHandler();
            Product product = handler.getSelectedAd(id);

            titleTextBox.Text = product.Title;
            descriptionTextBox.Text = product.Desc;
            priceTextBox.Text = product.Price;
            typeTextBox.Text = product.Type;
            categoryTextBox.Text = Database.getCategoryNameById(Convert.ToInt32(product.CategoryId));
            dateTextBox.Text = product.Date;

            ownerTextBox.Text = product.Owner.Username;
            phoneTextBox.Text = product.Owner.Phone.ToString();
            emailTextBox.Text = product.Owner.Email;
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            Database.clearViewHistory();
            refreshViewHistory();

        }

        private void refreshViewHistory()
        {

            listViewHistoryPage.Items.Clear();
            listViewHistoryPage.Columns.Clear();

            listViewHistoryPage.View = System.Windows.Forms.View.Details;
            listViewHistoryPage.GridLines = true;
            listViewHistoryPage.FullRowSelect = true;

            var list = new List<Product>();

            List<Product> allProducts = Database.getProductsInViewHistoryOfLoggedUser();


            listViewHistoryPage.Columns.Add("Id", 25);
            listViewHistoryPage.Columns.Add("Title", 100);
            listViewHistoryPage.Columns.Add("Description", 200);
            listViewHistoryPage.Columns.Add("Price", 50);
            listViewHistoryPage.Columns.Add("Type", 50);
            listViewHistoryPage.Columns.Add("Category", 100);
            listViewHistoryPage.Columns.Add("Date", 100);

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
                    listViewHistoryPage.Items.Add(itm);
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = null;

            if (listViewHistoryPage.SelectedItems.Count > 0)
            {
                id = listViewHistoryPage.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                MessageBox.Show("Choose an ad.");
                return;
            }

            AdHandler handler = new AdHandler();
            Product product = handler.getSelectedAd(id);

            Database.removeEntryFromViewHistroy(product);
            refreshViewHistory();
        }
    }
}
