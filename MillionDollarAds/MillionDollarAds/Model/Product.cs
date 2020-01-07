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

        public Product(string owner, string desc, string id, string image, string price, string title, string type, string date)
        {
            Owner = owner;
            Desc = desc;
            Id = id;
            Image= image;
            Price = price;
            Title = title;
            Type = type;
            Date = date;
        }

        public string Owner { get; set; }
        public string Desc { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
    }
}
