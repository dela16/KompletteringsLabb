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
    /// Interaction logic for CashierView.xaml
    /// </summary>
    public partial class CashierView : UserControl
    {
        public CashierView()
        {
            InitializeComponent();

            int sum = 0;

            TotalSum.Text = "The sum is " + sum + " Sek."; 
        }

        private void Yesbtn_Click_1(object sender, RoutedEventArgs e)
        {
            //Om tid finns så utarbeta denna mer, en plånbok exepmelvis.
            MessageBox.Show("Payment Succeedded!");
        }

        private void Nobtn_Click(object sender, RoutedEventArgs e)
        {
            StoreView.Visibility = Visibility.Visible; 
        }
    }
}
