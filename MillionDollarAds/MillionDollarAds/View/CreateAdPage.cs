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

        private void CreateAdPage_Load(object sender, EventArgs e)
        {
            List<Category> categories = null;
            categories = Database.getAllCategories();
            Category[] cat = categories.ToArray();

            for ( int i =0; i< categories.Count; i++)
            {
                categoryComboBox.Items.Add("   " + cat[i].Title);
            }
        }

        private void createAdButton_Click(object sender, EventArgs e)
        {

        }
    }
}
