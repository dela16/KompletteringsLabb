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
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        public StoreView()
        {            
            List<Product> products = ProductManager.GetProducts();//Denna är fel. Här ska det vara typ Store.Storage.


            InitializeComponent();            
            //ProductsInStore.ItemsSource=Store.Storage; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 

            this.DataContext = ProductManager.products;
            //ProductsInStore.Items.Add(Store.Storage); //Något sånt för att få det att synas hos kunden. 
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            User userCart = new User();

            // userCart.Cart = ProductsInStore.Items.Add(ProductsInStore.SelectedItem); Oklart vad denna gör. 
            //hur få in den i vår lista på profilen?
            string input = Interaction.InputBox("Prompt", "Add to stock", "How many?", 0, 0);

            //CustomerProfileView.ShoppingCart.ItemsSource = ProductsInStore.Items.Add(ProductsInStore.SelectedItem); //Här lägger vi till produkten i vår kundkorg. 
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
             CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
