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
using System.Drawing.Printing;

namespace MillionDollarAds.View



{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            Initialize();         
            
        }

        public string id = null;

        public ListView getListViewHomePage
        {
            get { return listViewHomePage; }
        }
        public Button getEditAdButton
        {
            get { return editAd; }
        }

        public string selectedId = null;
        public string getSelectedId
        {
            get { return id; }
        }
       

        private void showAdButton_Click(object sender, EventArgs e)
        {
            //string id = null;
            showAdPanel.Visible = true;

            if (listViewHomePage.SelectedItems.Count > 0)
            {
                id = listViewHomePage.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                MessageBox.Show("Choose an ad.");
                return;
            }

            AdHandler handler = new AdHandler();
            Product product = handler.getSelectedAd(id);
            
            titleTextBox.Text = product.Title;
            descriptionTextBox.Text = product.Desc;
            priceTextBox.Text = product.Price;
            typeTextBox.Text = product.Type;
            categoryTextBox.Text = Database.getCategoryNameById( Convert.ToInt32(product.CategoryId) );
            dateTextBox.Text = product.Date;

            ownerTextBox.Text = product.Owner.Username;
            phoneTextBox.Text = product.Owner.Phone.ToString();
            emailTextBox.Text = product.Owner.Email;

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

           
        private void listViewHomePage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string id = null;

            if (listViewHomePage.SelectedItems.Count > 0)
            {
                id = listViewHomePage.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                return;
            }

            AdHandler handler = new AdHandler();
            Product product = handler.getSelectedAd(id);

            if (Arxikh.user != null && (product.Owner.Id == Arxikh.user.Id))
            {
                editAd.Visible = true;
                selectedId = id;
            }
            else
            {
                editAd.Visible = false;
            }
        }

        private void editAd_Click(object sender, EventArgs e)
        {
            if(listViewHomePage.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewHomePage.SelectedItems[0];
                Product p = Database.getAdbyId(item.Text);
                EditAdForm editAdForm = new EditAdForm(p);
                editAdForm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           Print();
        }

        void Print()
        {
            PrintDocument PrintDocument = new PrintDocument();
            PrintDocument.PrintPage += (object sender, PrintPageEventArgs e) =>
            {
                Font font = new Font("Arial", 12);
                float offset = e.MarginBounds.Top;
                foreach (ListViewItem Item in listViewHomePage.SelectedItems)
                {
                    Product p = Database.getAdbyId(Item.Text);
                    // The 5.0f is to add a small space between lines
                    offset += (font.GetHeight() + 10.0f);
                    PointF location = new System.Drawing.PointF(e.MarginBounds.Left, offset);
                    e.Graphics.DrawString("*** " + p.Title + " ***\t"+p.Desc + "\t" + p.Price + "\t" + p.Owner.Phone + "(" + p.Owner.Email + ")\n", font, Brushes.Black, location);
                    e.Graphics.DrawString("______________________________________________________________________________\n", font, Brushes.Black, location);                    
                }
            };
            PrintDocument.Print();
        }
    }
}
