using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp4.Models;

namespace WpfApp4.ViewModels
{
    public class DeliveryService : IDeliveryService
    {
        public void Deliver(string address, Product product)
        {
            MessageBox.Show($"Товар {product.Name} доставлен по адресу: {address}");
        }
    }
}
