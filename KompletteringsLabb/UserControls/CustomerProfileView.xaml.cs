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
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : UserControl
    {
        public static CustomerProfileView CustomerProfileViewObject { get; set; } //denna gör så att jag kan komma åt en metod härifrån i en annan cs fil. 
        public CustomerProfileView()
        {
            InitializeComponent();
            CustomerProfileViewObject = this;
            ShoppingCart.ItemsSource = CustomerManager.CurrentCustomer.Cart;

            //UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}"; // Denna skrivs in i vyn innan istället. 

        }

        public void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.SelectedItem != null)
            {
                string input = Interaction.InputBox("How many of the chosen product do you want to delete from your cart? OBS! Numeric numbers only!", "Delete Products", "", 0, 0);
                double amomuntToRemove = double.Parse(input);

                if (((ProductStock)ShoppingCart.SelectedItem).Stock > amomuntToRemove)
                {
                    ((ProductStock)ShoppingCart.SelectedItem).Stock = ((ProductStock)ShoppingCart.SelectedItem).Stock-amomuntToRemove;
                }
                else if (((ProductStock)ShoppingCart.SelectedItem).Stock == amomuntToRemove)
                {
                    CustomerManager.CurrentCustomer.Cart.Remove((ProductStock)ShoppingCart.SelectedItem);
                }
                else if (amomuntToRemove == double.Parse(" ") || amomuntToRemove == double.Parse(""))
                {
                    MessageBox.Show("You have to put in an amount. Obs! Numeric numbers only!");
                }
                else
                {
                    MessageBox.Show("You can't take away more products than you have in your cart.");
                }

                UpdateCartMethod(); 
            }
            else
            {
                MessageBox.Show("You have not selected a product.");
            }
        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {

            StoreView.Store.ItemsSource = StoreManager.CurrentStore.Storage; //Här sätter vi det som ska synas i butiken på nästa vy. 
            //Vi lägger inte in koden på "sin" sida utan i steget före. 
            StoreView.Visibility = Visibility.Visible;
        }

        public void UpdateCartMethod()
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

        }
        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager.CurrentCustomer = null; //Här loggar vi ut officiellt från kunden. 
            ShoppingCart.ItemsSource = null; 
            ShoppingCart.Items.Clear();
            MessageBox.Show("Logout has been succeeded.");
            Visibility = Visibility.Collapsed;
        }


    }
}
