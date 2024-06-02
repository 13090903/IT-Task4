using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Models
{
    public class Customer
    {
        public string? Name { get; set; }

        public void BuyProduct(Store tradePoint, Product product)
        {
            tradePoint.SellProduct(product);
        }
    }
}
