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

        public Category(int id, string title, int hasFather)
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
