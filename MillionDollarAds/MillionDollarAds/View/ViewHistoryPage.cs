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
    }
}
