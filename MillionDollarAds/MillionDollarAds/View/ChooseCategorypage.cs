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
    public partial class ChooseCategorypage : UserControl
    {
        Arxikh main;
        public ChooseCategorypage()
        {
            InitializeComponent();
        }
        public ListView getListViewHomePage
        {
            get { return listView1; }
        }

        private void ChooseCategorypage_Load(object sender, EventArgs e)
        {
            List<Category> categories = Database.getSubCategoriesByFather(1);
            foreach(Category category in categories)
            {
            comboBox1.Items.Add(category.Title);
            }            
        }
    }
}
