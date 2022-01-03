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
            
            //ProductsInStore.ItemsSource=Store.Storage; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 
          
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            User userCart = new User(); //används ens denna? 

            //ProductStock productStock = (ProductStock)Store.SelectedItem; //Denna är en referens. 
            string input = Interaction.InputBox("Prompt", "Add to cart", "How many?", 0, 0); // ska denna vara kvar eller krånglar det till allt? 
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
                //om du har produkterna i korgen redan så öka antalet annars add. 
                for (int i = 0; i < productStockToAdd.Stock; i++)
                {
                    CustomerManager.CurrentCustomer.Cart.Add(productStockToAdd); 
                    MessageBox.Show("Products added to cart.");
                }
                return; 
            }
            else
            {
                CustomerManager.CurrentCustomer.Cart.Add(productStockToAdd);//Borde inte denna visas i shoppingcart nu?!
                MessageBox.Show("" + amountOfProducts + (ProductStock)Store.SelectedItem + " added to your shoppingcart.");
            }

            ((ProductStock)Store.SelectedItem).Stock -= amountOfProducts; //Här sänker vi antalet i lagret för butiken.
            // if contains product så öka annars lägg till. 


            //CustomerProfileView.ShoppingCart.ItemsSource = userCart;

            ////CustomerProfileView.ShoppingCart.ItemsSource = StoreManager.CurrentStore.SelectedItems;
            ////productStock.Product = product;
            ////productStock.Stock = amountOfProducts;

            //CustomerProfileView.ShoppingCart.Add(userCart);
            //this.DataContext = CustomerProfileView.CurrentStore.product;
            
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
             CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
