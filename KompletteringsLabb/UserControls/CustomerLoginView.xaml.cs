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
    /// Interaction logic for CustomerLoginView.xaml
    /// </summary>
    public partial class CustomerLoginView : UserControl
    {
        public CustomerLoginView()
        {
            User user = new User(); 

            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed; 
        }

        private void CreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerView.Visibility = Visibility.Visible;
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            user.Name = CustomerName.Text;
            user.Password = CustomerPassword.Text;

            if (StoreManager.CurrentStore.LogInUser(user))
            {

                CustomerProfileView.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password, Please try again.");
            }


            CustomerName.Clear();
            CustomerPassword.Clear();

            CustomerProfileView.UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}";

        }
    }
}
