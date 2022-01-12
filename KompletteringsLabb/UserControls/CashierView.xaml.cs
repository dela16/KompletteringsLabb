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

            updateTotalSum(); 

        }

       
        //public void Yesbtn_Click(object sender, RoutedEventArgs e)//
        private async void Yesbtn_Click(object sender, RoutedEventArgs e)
        {
            //Kan utarbeta denna mer, en plånbok exepmelvis osv. Men inte denna gången!

            await CheckOut(CustomerManager.CurrentCustomer);
        }

        private void Nobtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCartMethod();
        }


        private async Task CheckOut(User customer)
        {

            //Nedanför sänker vi antalet i lagret för butiken.
            //Vi kollar produkterna i kundvagnen, jämför dom med produkterna i lagret och sänker från lagret när vi handlar. 
            foreach (var customerProductStock in customer.Cart)
            {
                foreach (var storeProductStock in StoreManager.CurrentStore.Storage)
                {
                    if (storeProductStock.Product == customerProductStock.Product)
                    {
                        storeProductStock.Stock -= customerProductStock.Stock;
                    }
                }
            }

           MessageBox.Show("You have payed. Thank you, come again. ");
           ProductsInCart.ItemsSource = null; 
           ProductsInCart.Items.Clear();//Vi behöver göra null när vi vill ta bort items ur det visuella. 
           customer.Cart.Clear();
           updateTotalSum();
           logOut(); 
        }

        public void updateTotalSum()
        {
            double sum = 0;

            foreach (var productStock in CustomerManager.CurrentCustomer.Cart)
            {
                sum += productStock.Product.Price * productStock.Stock;
            }
            TotalSum.Text = "Total sum: " + sum.ToString();
        }

        private void logOut()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
