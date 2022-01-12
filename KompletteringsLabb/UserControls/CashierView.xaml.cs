using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for CashierView.xaml
    /// </summary>
    public partial class CashierView : UserControl
    {
        public CashierView()
        {
            InitializeComponent();

            ProductsInCart.ItemsSource = CustomerManager.CurrentCustomer.Cart;
            int sum = 0;
        }


        public void UpdateCartMethod()
        {
            ProductsInCart.ItemsSource = null;
            ProductsInCart.Items.Clear();
            List<ProductStock> pStock = new(CustomerManager.CurrentCustomer.Cart);
            ProductsInCart.ItemsSource = pStock;

            double sum = 0;

            foreach (var productStock in CustomerManager.CurrentCustomer.Cart)
            {
                sum += productStock.Product.Price * productStock.Stock;
            }
            TotalSum.Text = "Total sum: " + sum.ToString();

        }

        public void Yesbtn_Click(object sender, RoutedEventArgs e)//private async Task Yesbtn_Click(object sender, RoutedEventArgs e)
        {//TODO knappen funkar ej. 
            //Kan utarbeta denna mer, en plånbok exepmelvis.

            //Här sänker vi antalet i lagret för butiken.
            //Vi kollar produkterna i kundvagnen, jämför dom med produkterna i lagret och sänker från lagret när vi handlar. 
            foreach (var customerProductStock in CustomerManager.CurrentCustomer.Cart)
            {
                foreach (var storeProductStock in StoreManager.CurrentStore.Storage)
                {
                    if (storeProductStock.Product == customerProductStock.Product)
                    {
                        storeProductStock.Stock -= customerProductStock.Stock; 
                    }
                }
            }

          // await ClearAndCheckout(); //TODO anropas med await.
        }

        private void Nobtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCartMethod();
        }

        private void ClearAndCheckout()
        {
            MessageBox.Show("You have payed. Thank you, come again. ");
            ProductsInCart.Items.Clear();
            //CustomerProfileView.ShoppingCart.Items.Clear();
        }

    }
}
