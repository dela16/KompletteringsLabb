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

            TotalSum.Text = "The sum is " + sum + " Sek.";
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

        //private async Task Yesbtn_ClickAsync(object sender, RoutedEventArgs e)
        //{
        //    //Kan utarbeta denna mer, en plånbok exepmelvis.

        //    ((ProductStock)StoreView.Store.SelectedItem).Stock -= amountOfProducts; //Här sänker vi antalet i lagret för butiken.
        //    MessageBox.Show("You have payed. Thank you, come again. ");
        //    ClearAndCheckout();
        //}

        private void Nobtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCartMethod();
        }

        //private async Task ClearAndCheckout()
        //{
        //    ProductsInCart.Clear();
        //    CustomerProfileView.ShoppingCart.Clear();
        //    await CheckOut(); //Vi vill ju koppla denna till Store Checkout. 
        //}
    }
}
