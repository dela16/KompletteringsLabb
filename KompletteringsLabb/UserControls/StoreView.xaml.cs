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
            InitializeComponent();
          
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            //CustomerProfileView.ShoppingCart.ItemsSource = CustomerManager.CurrentCustomer.Cart;
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0; 
            //ProductStock productStock = (ProductStock)Store.SelectedItem; //Denna är en referens. 

            if (((ProductStock)Store.SelectedItem) == null )
            {
                MessageBox.Show("You have to select an item.");
                return;
            }

            string input = Interaction.InputBox("How many would you like to add? OBS! Numeric Numbers only!", "Add to cart", "", 0, 0);

            if (input == " " || input == "")
            {
                MessageBox.Show("You have to write a number.");
                return;
            }

            int amountOfProducts = int.Parse(input);

            if (((ProductStock)Store.SelectedItem).Stock < amountOfProducts)
            {
                MessageBox.Show("Not enough products in Stock");
                return;
            }
            
            var productStockToAdd = new ProductStock();
            var productToAdd = new Product();

            productToAdd.Name = ((ProductStock)Store.SelectedItem).Product.Name; //Med hjälp av detta refererar vi inte längre.
            productToAdd.Price = ((ProductStock)Store.SelectedItem).Product.Price;
            productStockToAdd.Product = productToAdd;
            productStockToAdd.Stock = amountOfProducts;


            if (CustomerManager.CurrentCustomer.Cart.Contains((ProductStock)Store.SelectedItem))
            {
                //Går att fördjupa genom att lägga samma produkter på en och samma rad. Om vi lägger till den vid flera tillfällen.  

                for (int i = 0; i < productStockToAdd.Stock; i++)
                {
                    //CustomerManager.CurrentCustomer.Cart.Add(); 
                    MessageBox.Show("Products added to cart.");
                }
                return; 
            }
            else
            {
                CustomerManager.CurrentCustomer.Cart.Add(productStockToAdd);
                MessageBox.Show("" + amountOfProducts + " " + ((ProductStock)Store.SelectedItem).Product.Name + " added to your shoppingcart.");
            }

            //((ProductStock)Store.SelectedItem).Stock -= amountOfProducts; //Antingen kan jag paxa produkterna och göra det omöjligt
            //För en kund att lägga till i sin kundkorg redan här eller så försvinner de från andra kunders vyer först när jag checkar ut. 
            //Testar att lägga det vid utcheckning. Som kund hade jag nog blivit sur oavsett scenario. 

        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
