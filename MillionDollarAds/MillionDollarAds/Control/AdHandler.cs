using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionDollarAds.View;

namespace MillionDollarAds.Control
{
    public class AdHandler
    {
        private Product Product { set; get; }

        public AdHandler() { }

        public AdHandler(Product product)
        {
            Product = product;
        }

        public bool createAd()
        {
            if ( string.IsNullOrWhiteSpace(Product.Title) 
                || string.IsNullOrWhiteSpace(Product.Desc)
                || string.IsNullOrWhiteSpace(Product.Price)
                || string.IsNullOrWhiteSpace(Product.Date)
                || string.IsNullOrWhiteSpace(Product.Type) )
            {
                return false;
            }

                return true;
        }

        public Product getSelectedAd(string id)
        {
            return Database.getAdbyId(id);
        }
    }
}
