using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4.Models
{
    public class Store
    {
        public event EventHandler<Product>? ProductSoldOut;
        public event EventHandler<Product>? ProductPurchased;

        private readonly List<Product> _products = new List<Product>();

        public IReadOnlyList<Product> Products => _products;

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void SellProduct(Product product)
        {
            if (_products.Contains(product))
            {
                if (product.Amount > 0)
                {
                    product.Amount--;
                    ProductPurchased?.Invoke(this, product);
                }
                else
                {
                    ProductSoldOut?.Invoke(this, product);
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }
    }
}
