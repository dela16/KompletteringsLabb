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
            string input = Interaction.InputBox("Prompt", "Add to cart", "How many?", 0, 0);
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
                int oldAdd;
                int newAdd;
                int total;

                //om du har produkterna i korgen redan så öka antalet med så många till som du lägger på (på samma rad) annars add. 

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

            ((ProductStock)Store.SelectedItem).Stock -= amountOfProducts; //Här sänker vi antalet i lagret för butiken.

        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
             CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
