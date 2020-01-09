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

        public Category(int hasFather, int id,  string title)
        {
            HasFather = hasFather;
            Id = id;
            Title = title;
        }

        public int HasFather { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }








    }
}
