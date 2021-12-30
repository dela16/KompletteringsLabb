using KompletteringsLabb.Models;
using Microsoft.VisualBasic;
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
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        public StoreView()
        {
            InitializeComponent();

            //ProductsInStore.ItemsSource=Store.Storage; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 
          
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            User userCart = new User();

            ProductStock productStock = (ProductStock)Store.SelectedItem;
            string input = Interaction.InputBox("Prompt", "Add to cart", "How many?", 0, 0);
            int amountOfProducts = int.Parse(input);


           // CustomerProfileView.ShoppingCart.Items.Add(new { Name = product.Name, Price = product.Price, Amount = amountOfProducts });

            CustomerManager.CurrentCustomer.Cart.Add(productStock.Product);//Borde inte denna vara Product.product typ?

            //CustomerProfileView.ShoppingCart.ItemsSource = userCart;

            ////CustomerProfileView.ShoppingCart.ItemsSource = StoreManager.CurrentStore.SelectedItems; Försökte få det att lite store.
            ////productStock.Product = product;
            ////productStock.Stock = amountOfProducts;

            //CustomerProfileView.ShoppingCart.Add(userCart);
            //this.DataContext = CustomerProfileView.CurrentStore.product;

        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
             CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
