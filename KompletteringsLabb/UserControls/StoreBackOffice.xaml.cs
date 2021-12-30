using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using System.Windows.Data;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for StoreBackOffice.xaml
    /// </summary>
    public partial class StoreBackOffice : UserControl
    {
        public StoreBackOffice()
        {
            InitializeComponent();

            ProductsToAdd.ItemsSource = ProductManager.Products; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 

            this.DataContext = ProductManager.Products;

        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            ProductStock productStock = new ProductStock();

            Product product = (Product)ProductsToAdd.SelectedItem;
            string input = Interaction.InputBox("Prompt", "Add to stock", "How many?", 0, 0);
            int amountOfProducts = int.Parse(input);

            ProductsInStore.Items.Add(new { Name = product.Name, Price = product.Price, Amount = amountOfProducts, TotalCost = product.Price * amountOfProducts });
            productStock.Product = product;
            productStock.Stock = amountOfProducts;

            StoreManager.CurrentStore.Storage.Add(productStock);// Här lägger vi till den i lagret på affären och det som hamnar i fil sedan. Ovan lägger vi till dom i listvyn bara. 
        }

        private async void savebtn_Click(object sender, RoutedEventArgs e)
        {
            await saveStorageToFile();

            MessageBox.Show("Storage saved");
        }

        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här listviewn?

        internal async Task saveStorageToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Storage.json";

            using FileStream createStream = File.Create(path + fileNameStore);
            await JsonSerializer.SerializeAsync(createStream, StoreManager.CurrentStore.Storage);
            await createStream.DisposeAsync();

        }


    }
}
