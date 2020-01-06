using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds
{
    class Product
    {
        public Product()
        {
        }

        public Product(string desc, string id, string image, string price, string title)
        {
            Desc = desc;
            Id = id;
            Image= image;
            Price = price;
            Title = title;
        }

        public string Desc { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }








    }
}
