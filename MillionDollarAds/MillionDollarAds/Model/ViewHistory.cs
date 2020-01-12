using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds.Model
{
    public class ViewHistory
    {
        public User user { set; get; }
        public List<Product> products { set; get; }
    }
}
