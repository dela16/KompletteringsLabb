﻿using KompletteringsLabb.Models;
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
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : UserControl
    {
        public CustomerProfileView()
        {
            InitializeComponent();

            ShoppingCart.ItemsSource = CustomerManager.CurrentCustomer.Cart;

            //UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}"; // Denna skrivs in i vyn innan istället. 

        }

        public void Removebtn_Click(object sender, RoutedEventArgs e)
        {

            if (ShoppingCart.SelectedItem != null)
            {
                string input = Interaction.InputBox("How many of the chosen product do you want to delete from your cart?", "Delete Products", "", 0, 0);
                int amountOfProducts = int.Parse(input);

                if (CustomerManager.CurrentCustomer.((ProductStock)ShoppingCart.SelectedItem) <= amountOfProducts)
                {//Om varan finns i min kundkorg och jag vill ta bort amountOfProducts som finns i. (ex. Ta bort 2 av 3).
                    CustomerManager.CurrentCustomer.Cart.Remove(amountOfProducts); 
                }

                //((ProductStock)Store.SelectedItem).Stock += amountOfProducts; //TODO om vi remove från cart - lägg till i lagret igen?

                UpdateCartMethod(); 
            }
            else
            {
                MessageBox.Show("You have not selected a product.");
            }

        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {

            StoreView.Store.ItemsSource = StoreManager.CurrentStore.Storage; //Här sätter vi det som ska synas i butiken på nästa vy. 
            //Vi lägger inte in koden på "sin" sida utan i steget före. 

            StoreView.Visibility = Visibility.Visible;
        }

        public void UpdateCartMethod()
        {
            ShoppingCart.ItemsSource = null;
            ShoppingCart.Items.Clear();
            List<ProductStock> pStock = new(CustomerManager.CurrentCustomer.Cart);
            ShoppingCart.ItemsSource = pStock;

        }
        private void UpdateCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ItemsSource = null;
            ShoppingCart.Items.Clear();
            List<ProductStock> pStock = new(CustomerManager.CurrentCustomer.Cart);
            ShoppingCart.ItemsSource = pStock;

            double sum = 0;

            foreach (var productStock in CustomerManager.CurrentCustomer.Cart)
            {
                sum += productStock.Product.Price * productStock.Stock;
            }
            Sum.Text = sum.ToString();

            //Denna har varit krånglig för att få till kundvagnsvyn med store vyns add funktion. 
            //Ville helst inte ha det på det här sättet, Jag ville att det skulle ske automatiskt. 
            //Men efter många timmar så var det denna som fungerar så då tar jag den vinsten!

        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager.CurrentCustomer = null; //  Här loggar vi ut officiellt från kunden. 
            ShoppingCart.Items.Clear();
            Visibility = Visibility.Collapsed; 
        }


    }
}
