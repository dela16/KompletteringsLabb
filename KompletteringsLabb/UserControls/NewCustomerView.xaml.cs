using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for NewCustomerView.xaml
    /// </summary>
    public partial class NewCustomerView : UserControl
    {
        public NewCustomerView()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            //CustomerProfileView.Visibility = Visibility.Visible; 
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
