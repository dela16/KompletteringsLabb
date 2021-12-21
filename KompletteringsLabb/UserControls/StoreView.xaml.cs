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
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        public StoreView()
        {
            //ProductManager productManager = new ProductManager(); //Tror inte denna är rätt

            InitializeComponent();
            //ProductsInStore.Row.Add();
            //StoreManager.currentStore.Storage.itemsSource = ProductManager.products;

            //ProductsInStore.Items.Add(productManager.GetProducts()); 

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            //User userCart = new User();

            //userCart.Cart = ProductsInStore.SelectedItem;
            ////hur få in den i vår lista på profilen?
            //User.Cart.Add(userCart);

            //if (ProductsInStore.SelectedItem != null) //Har vi fått till add knappen nu? 
            //{
            //    CustomerProfileView.ShoppingCart.Items.Add(ProductsInStore.SelectedItem);
            //}
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
             CashierView.Visibility = Visibility.Visible;
        }
    }
}
