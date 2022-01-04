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
            InitializeComponent();

            ShoppingCart.ItemsSource = CustomerManager.CurrentCustomer.Cart;

            //this.DataContext = CustomerManager.CurrentCustomer.Cart;

            //List<ProductStock> customerCart = CustomerManager.CurrentCustomer.Cart; //Vi nämner ju aldrig att den ska hämta från shoppingcarten?
            User user = new User();


            //UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}"; // Denna skrivs in i vyn innan istället. 

        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.SelectedItem != null)
            {
                ShoppingCart.Items.Remove(ShoppingCart.SelectedItem);
            }
        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {

            StoreView.Store.ItemsSource = StoreManager.CurrentStore.Storage; //Här sätter vi det som ska synas i butiken på nästa vy. 
            //Vi lägger inte in koden på "sin" sida utan i steget före. 
            //Todo Programmet kraschar om jag klickar bakåt, lägger till en produkt och sedan in igen som kund. 

            StoreView.Visibility = Visibility.Visible;

        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager.CurrentCustomer = null; //  Här loggar vi ut officiellt från kunden. 
            ShoppingCart.Items.Clear();
            Visibility = Visibility.Collapsed; 
        }

        private void UpdateCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ItemsSource = null;
            ShoppingCart.Items.Clear();
            List<ProductStock> pStock = new(CustomerManager.CurrentCustomer.Cart); 
            ShoppingCart.ItemsSource = pStock;

            double sum = 0;

            foreach (var productStock in CustomerManager.CurrentCustomer.Cart)
            {
                sum += productStock.Product.Price * productStock.Stock;
            }
            Sum.Text = sum.ToString();

            //Denna har varit krånglig för att få till kundvagnsvyn med store vyns add funktion. 
            //Ville helst inte ha det på det här sättet, Jag ville att det skulle ske automatiskt. 
            //Men efter många timmar så var det denna som fungerar så då tar jag den vinsten!

        }
    }
}
