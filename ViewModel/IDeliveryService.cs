using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Models;

namespace WpfApp4.ViewModels
{
    public interface IDeliveryService
    {
        void Deliver(string address, Product product);
    }
}
