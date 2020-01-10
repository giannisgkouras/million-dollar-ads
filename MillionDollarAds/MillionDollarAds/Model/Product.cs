using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds
{
    public class Product
    {
        public Product()
        {
        }

        public Product(User owner, string desc, int id, string price, string title, string type, string date , int categoryId)
        {
            Owner = owner;
            Desc = desc;
            Id = id;
            Price = price;
            Title = title;
            Type = type;
            Date = date;
            CategoryId = categoryId;
        }

        public User Owner { get; set; }
        public string Desc { get; set; }
        public int Id { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int CategoryId { get; set; }
        
    }
}
