﻿using KompletteringsLabb.Models;
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

            this.DataContext = CustomerManager.CurrentCustomer.Cart;

            Product product = new Product(); 
            User user = new User();
            int sum = 0;

           // TotalSum.Text = sum += product.Price * product.Amount;  //denna kan bli fel...Får se när vi kan se produkterna i vyn. 

            //UserName.Text = $"Welcome back {CustomerManager.CurrentCustomer.Name}"; // Denna skrivs in i vyn innan istället. 
             //I listvyn, ska den kopplas till Products.product eller bör den bindas till mina selected items? 

        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.SelectedItem != null)
            {
                ShoppingCart.Items.Remove(ShoppingCart.SelectedItem);
            }
        }

        private void Storebtn_Click(object sender, RoutedEventArgs e)
        {

            StoreView.Store.ItemsSource = StoreManager.CurrentStore.Storage; //Här sätter vi det som ska synas i butiken på nästa vy. 
            //Vi lägger inte in koden på "sin" sida utan i steget före. 
            //Todo Programmet kraschar om jag klickar bakåt, lägger till en produkt och sedan in igen som kund. 

            StoreView.Visibility = Visibility.Visible;

        }

        private void LogOutbtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager.CurrentCustomer = null; //  Här loggar vi ut officiellt från kunden. 
            ShoppingCart.Items.Clear();
            Visibility = Visibility.Collapsed; 
        }

    }
}
