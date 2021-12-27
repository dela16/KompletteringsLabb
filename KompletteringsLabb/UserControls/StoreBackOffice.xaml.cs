﻿using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for StoreBackOffice.xaml
    /// </summary>
    public partial class StoreBackOffice : UserControl
    {
        Product product = new Product();
        Store storage = new Store(); 
        public StoreBackOffice()
        {
            InitializeComponent();
            //currentstore 
            List<Product> products = ProductManager.GetProducts();

            ProductsToAdd.ItemsSource = products; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 

            this.DataContext = ProductManager.products;
            //StoreManager.currentStore.Storage = ProductsInStore.Items; // ProductManager.products; 

            //saveStoreToFile(); 
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {

            //Pop-up ruta där man frågar hur många man vill lägga till? 
            ProductsInStore.Items.Add(ProductsToAdd.SelectedItem); 
            //StoreManager.CurrentStore.Storage.Add(ProductsInStore.ItemsSource);

        }

        //Här bör det finnas en metod som är kopplad till produkt klassen och en lista över olika produkter. 
        //En add metod som tar produkt från ena stället till det andra. 
        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här listviewn?
        //Räkna ut antalet för varje kolumn samt kostnaden. Automatisk ändring. 

        internal async Task saveStoreToFile()
        {
            Store store = new Store(); 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Store.json";

            using FileStream createStream = File.Create(path + fileNameStore); //fullPath ska vara path + filnamn, typ Path.Combine(*path*, *filename*)
            await JsonSerializer.SerializeAsync(createStream, store);
            await createStream.DisposeAsync();
        }


    }
}
