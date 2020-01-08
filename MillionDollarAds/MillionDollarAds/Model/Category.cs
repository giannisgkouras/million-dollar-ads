using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds
{
    class Category
    {
        public Category()
        {
        }

        public Category(string hasFather, string id,  string title)
        {
            HasFather = hasFather;
            Id = id;
            Title = title;
        }

        public string HasFather { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }








    }
}
