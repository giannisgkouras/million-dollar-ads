﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionDollarAds.View

{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public ListView getListViewHomePage
        {
            get { return listViewHomePage; }
        }

        private void showAdButton_Click(object sender, EventArgs e)
        {

        }
    }
}
