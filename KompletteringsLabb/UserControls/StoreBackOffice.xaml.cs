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
using System.Collections.Specialized;

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
            ProductsInStore.ItemsSource = StoreManager.CurrentStore.Storage; //Den här gör så att jag ser redan existerande produkter i lagret som admin. 

            //UpdateTotalValue(); 
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

            productStock.Product = product;
            productStock.Stock = amountOfProducts;
            productStock.Total = productStock.Product.Price * productStock.Stock; 

            StoreManager.CurrentStore.Storage.Add(productStock);// Här lägger vi till den i lagret på affären och det som hamnar i fil sedan. Ovan lägger vi till dom i listvyn bara. 
        }

        private async void savebtn_Click(object sender, RoutedEventArgs e)
        {
            await saveStorageToFile();

            MessageBox.Show("Storage saved");
        }

        internal async Task saveStorageToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Storage.json";

            using FileStream createStream = File.Create(path + fileNameStore);
            await JsonSerializer.SerializeAsync(createStream, StoreManager.CurrentStore.Storage);
            await createStream.DisposeAsync();

        }

        public void UpdateTotalValue()
        {
            foreach (var productStock in StoreManager.CurrentStore.Storage)
            {
                productStock.Total = productStock.Product.Price * productStock.Stock;
            }
            //Denna är skapad för att se till så att ingen "grundlager-produkt" har 0 i sig. 
            //Från och med nu så kommer total value uppdateras tack vare rad 47. 
        }

    }
}
