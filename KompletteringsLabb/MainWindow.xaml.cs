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

namespace KompletteringsLabb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StoreNameTextBox.Text = Store.StoreObject.StoreName;
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {

            AdminLoginView.Visibility = Visibility.Visible;
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerLoginView.Visibility = Visibility.Visible;
        }
    }
}
