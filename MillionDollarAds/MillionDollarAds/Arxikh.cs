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
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        private void button1_Click_1(object sender, EventArgs e)
        {
           // openConnection();
            listView1.View = System.Windows.Forms.View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

           // FirebaseResponse response = client.Get(@"MillionDollarAds/AdsByCategory/8");

            //dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Product>();

           // foreach (var item in data)
            //{
           //     list.Add(JsonConvert.DeserializeObject<Product>(((JProperty)item).Value.ToString()));
           // }


            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Description", 200);
            listView1.Columns.Add("Price",100);
            listView1.Columns.Add("Image",100);
            listView1.Columns.Add("Type",100);
            listView1.Columns.Add("Owner", 100);
            listView1.Columns.Add("Date", 100);

            ListViewItem itm;

            foreach (Product products in list)
            {
                Invoke((MethodInvoker)delegate
                {
                    itm = new ListViewItem(new string[] { products.Title, products.Desc, products.Price, products.Type, products.Owner.Username, products.Date, });
                    listView1.Items.Add(itm);
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
  
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Control.Database.Initialize();
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
    }
}
