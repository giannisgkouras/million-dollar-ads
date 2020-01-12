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
    public partial class CreateAdPage : UserControl
    {
        public CreateAdPage()
        {
            InitializeComponent();
        }

        Arxikh mainForm;
        public CreateAdPage(Form callingForm)
        {
            mainForm = callingForm as Arxikh;
            InitializeComponent();
        }

        private void CreateAdPage_Load(object sender, EventArgs e)
        {
            List<Category> categories = null;
            categories = Database.getAllCategories();
            Category[] cat = categories.ToArray();

            for ( int i =0; i< categories.Count; i++)
            {
                categoryComboBox.Items.Add(cat[i].Title);
            }
        }

        private void createAdButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            string price = priceTextBox.Text;
            string type = (typeComboBox.SelectedItem as string) ;
            string category = (categoryComboBox.SelectedItem as string);
            int categoryId = Database.getCategoryIdByName(category);
            User owner = Arxikh.user;

            Product product = new Product
            {
                Title = title,
                Desc = description,
                Price = price,
                Type = type,
                CategoryId = categoryId,
                Date = System.DateTime.Today.ToString("dd/MM/yy"),
                Owner = owner
                
            };

            AdHandler handler = new AdHandler(product);

            if (handler.createAd())
            {
                Database.insertAd(product);
                MessageBox.Show("Your ad was created!");
                clearAllFields();


                this.mainForm.refreshAllAds();
                this.mainForm.getHomePage.BringToFront();
            }
            else
            {
                MessageBox.Show("Fill all the fields.");
            }

        }

        private void clearAllFields()
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            priceTextBox.Text = "";
            typeComboBox.SelectedItem = null;
            categoryComboBox.SelectedItem = null; 
        }

    }
}
