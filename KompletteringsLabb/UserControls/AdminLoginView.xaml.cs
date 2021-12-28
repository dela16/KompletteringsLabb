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
    /// Interaction logic for AdminLoginView.xaml
    /// </summary>
    public partial class AdminLoginView : UserControl
    {
        public AdminLoginView()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            AdminName.Clear();
            AdminPassword.Clear(); 
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            var admin = new User();
            admin.Name = AdminName.Text;
            admin.Password = AdminPassword.Text;

            if (StoreManager.CurrentStore.LogInAdmin(admin))
            {
                StoreBackOffice.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password, Please try again.");
            }
        }

        private void CreateAdmin_Click(object sender, RoutedEventArgs e)
        {
            NewAdminView.Visibility = Visibility.Visible;
        }
    }
}
