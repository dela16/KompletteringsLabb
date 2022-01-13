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
        }

        private void addToCart_Click(object sender, RoutedEventArgs e)
        {
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

            foreach (ProductStock produkt in CustomerManager.CurrentCustomer.Cart)
            {
                if (produkt.Product.Name == productStockToAdd.Product.Name)//Här gör vi så att om varan redan finns i vår lista, då slår vi ihop produkterna.
                {
                    produkt.Stock += amountOfProducts;
                    CustomerProfileView.CustomerProfileViewObject.UpdateCartMethod();
                    MessageBox.Show(amountOfProducts + " " + productStockToAdd.Product.Name + " added to your shoppingcart.");
                    return;
                }
            }
           
            CustomerManager.CurrentCustomer.Cart.Add(productStockToAdd);
            MessageBox.Show(amountOfProducts + " " + productStockToAdd.Product.Name + " added to your shoppingcart.");
            CustomerProfileView.CustomerProfileViewObject.UpdateCartMethod();

        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            CashierView.CashierViewObject.UpdateCartMethod(); 
            CashierView.Visibility = Visibility.Visible;
        }
        
    }
}
