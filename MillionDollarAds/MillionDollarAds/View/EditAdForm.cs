using MillionDollarAds.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionDollarAds.View
{
    public partial class EditAdForm : Form
    {
        int catId = 0;
        int productId = 0;
        public EditAdForm(Product p)
        {
            InitializeComponent();
            productBindingSource.DataSource = p;
            titleTB.Text = p.Title;
            descriptionTB.Text = p.Desc;
            priceTB.Text = p.Price;
            comboBox1.Text= p.Type;
            catId = p.CategoryId;
            productId = p.Id;

        }
        HomePage mainForm;
        public EditAdForm(HomePage callingForm)
        {
            mainForm = callingForm as HomePage;
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string title = titleTB.Text;
            string description = descriptionTB.Text;
            string price = priceTB.Text;
            string type = (comboBox1.SelectedItem as string);
            int categoryId = catId;
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
                Database.updateAd(product, productId);
                MessageBox.Show("Your ad was updated!");
                this.Close();                
            }
            else
            {
                MessageBox.Show("Fill all the fields.");
            }
            

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(this, "You really want to delete this ad?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Database.deleteteAdInViewHistory(productId);
                Database.deleteteAd(productId);
                MessageBox.Show("Your ad removed!");
                this.Close();
            }
            else return;
        }
    }
}
