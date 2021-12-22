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
            int sum = 0;

            //TotalSum.Text = sum += ShoppingCart.Price * ShoppingCart.Amount;  

            //CustomerLoginView.CustomerName.Text = UserName.Text; //Detta beror ju på vart ifrån användaern kom in... 
        }


        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.SelectedItem != null)//Vi borde kunna göra samma sak med att 
            {
                ShoppingCart.Items.Remove(ShoppingCart.SelectedItem);
            }
        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {
            ProductManager prodManager = new();

            //Visibility = Visibility.Collapsed;
            StoreView.Visibility = Visibility.Visible;
            //StoreView.ProductsInStore.Items = from product in prodManager.products select product.Name; 
        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.Items.Clear();
            CustomerLoginView.Visibility = Visibility.Visible; 
        }


        //UserName.Text=User.user;
    }
}
