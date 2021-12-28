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
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : UserControl
    {
        public CustomerProfileView()
        {
            Product product = new Product(); 
            User user = new User();
            InitializeComponent();
            int sum = 0;

           // TotalSum.Text = sum += ShoppingCart.Price * ShoppingCart.Amount;  

            //CustomerLoginView.CustomerName.Text = UserName.Text; //Detta beror ju på vart ifrån användaern kom in... 

            UserName.Text = "Welcome back "  ; // + CustomerLoginView.CustomerName.Text; Får inte till denna ännu. Behöver denna vara typ currentCustomer?
             //I listvyn, ska den kopplas till Products.product eller bör den bindas till mina selected items? 

            //Blir denna verkligen rätt nu? Den valda produkten i Store ska hamna i vår shoppingcart.
            //this.ShoppingCart.Items.Add(new { Product = StoreView.ProductsInStore.Items.Add(StoreView.product.SelectedItem), Amount = int.Parse(StoreView.input)});

        }

        //In case you want to add or remove elements after
        //setting the view's DataContext, use an ObservableCollection:
        //Behövs detta för mig? 

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.SelectedItem != null)
            {
                ShoppingCart.Items.Remove(ShoppingCart.SelectedItem);
            }
        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {
            ProductManager ProductManager = new();

            StoreView.Visibility = Visibility.Visible;
            StoreView.ProductsInStore.ItemsSource = from product in ProductManager.products select product.Name; 
        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.Items.Clear();
            Visibility = Visibility.Collapsed; 
        }


    }
}
