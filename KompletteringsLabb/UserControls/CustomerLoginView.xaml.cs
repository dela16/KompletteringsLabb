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
            List<User> CustomerList = CustomerManager.Customers; //Vad tänkte jag när jag skrev detta? Gjorde jag denna med Martin kanske? 

            //User user = new User(); Är det här en object reference? Bara att den inte funkar än? 

            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed; 
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            //Om UserName eller Password = false then Next view
            //if (CustomerName.Text == User.Name)
            //{
            //    if (CustomerPassword.Text == User.Password)
            //    {
            //        StoreView.Visibillity = visibility.visible; 
            //    }
            //}
            //Kolla med listorna över sparade användare. 
            MessageBox.Show("Incorrect UserName or Password, Please try again."); 
        }

        private void CreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerView.Visibility = Visibility.Visible;
        }
    }
}
