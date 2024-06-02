using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Models;
using WpfApp4.ViewModels;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private readonly Store _store;
        private readonly Customer _customer;
        private readonly DeliveryService _delivery;

        public MainWindow()
        {
            InitializeComponent();

            _store = new Store();

            _store.AddProduct(new Product { Name = "Молоко", Price = 65.0, Amount = 20 });
            _store.AddProduct(new Product { Name = "Динозавр", Price = 15000000.0, Amount = 1 });
            _store.AddProduct(new Product { Name = "Хлеб", Price = 40.0, Amount = 13 });
            _store.AddProduct(new Product { Name = "Шоколадка", Price = 80.0, Amount = 5 });
            _store.AddProduct(new Product { Name = "Диван", Price = 38000.0, Amount = 2 });
           
            _customer = new Customer();
            _delivery = new DeliveryService();

            _store.ProductPurchased += StorePurchase;
            _store.ProductSoldOut += OutOfStock;

            UpdateProducts();
        }

        private void UpdateProducts()
        {
            Products.Items.Clear();
            foreach (var product in _store.Products)
            {
                Products.Items.Add($"{product.Name} - {product.Price} рублей ({product.Amount} в наличии)");
            }
        }

        private void BuyClick(object sender, RoutedEventArgs product)
        {
            if (Products.SelectedIndex >= 0)
            {
                string productName = Products.SelectedItem.ToString().Split('-')[0].Trim();
                Product selectedProduct = _store.Products.FirstOrDefault(p => p.Name == productName);

                if (selectedProduct != null)
                {
                    _customer.BuyProduct(_store, selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Товар не выбран");
            }
        }

        private void StorePurchase(object sender, Product product)
        {
            UpdateProducts();
            MessageBox.Show($"{CustName.Text} купил товар {product.Name} за {product.Price} рублей");
            if (CustAddress.Text != "")
            {
                _delivery.Deliver(CustAddress.Text, product);
            }
        }

        private void OutOfStock(object sender, Product product)
        {
            MessageBox.Show($"Товар {product.Name} закончился");
            UpdateProducts();
        }
    }

}