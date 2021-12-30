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

            //UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}"; // Denna skrivs in i vyn innan istället. 
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

            StoreView.Store.ItemsSource = StoreManager.CurrentStore.Storage; //Todo Här sätter vi det som ska synas i butiken på nästa vy. 
            //Vi lägger inte in koden på "sin" sida utan i steget före. 
            //Todo Programmet kraschar om jag klickar bakåt, lägger till en produkt och sedan in igen som kund. 


            StoreView.Visibility = Visibility.Visible;

            this.DataContext = StoreManager.CurrentStore.Storage;
        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager.CurrentCustomer = null; //  Här loggar vi ut officiellt från kunden. 
            ShoppingCart.Items.Clear();
            Visibility = Visibility.Collapsed; 
        }

    }
}
