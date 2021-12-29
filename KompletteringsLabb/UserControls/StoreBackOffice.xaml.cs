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
        Product product = new Product();
        Store storage = new Store();

        public object Newtonsoft { get; private set; }

        public StoreBackOffice()
        {
            InitializeComponent();
            //currentstore 

            List<Product> products = ProductManager.GetProducts();

            ProductsToAdd.ItemsSource = products; //Den här gör så att vi ser produkterna i listvyn. Ihop med Binding i listvyn. 

            this.DataContext = ProductManager.products;

        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)ProductsToAdd.SelectedItem;
            string input = Interaction.InputBox("Prompt", "Add to stock", "How many?", 0, 0);
            int amountOfProducts = int.Parse(input);

            ProductsInStore.Items.Add(new { Name = product.Name, Price = product.Price, Amount = amountOfProducts, TotalCost = product.Price * amountOfProducts });
            StoreManager.ProductStock.Add(Product);// Denna är fel igen. Här lägger vi till den i lagret på affären. Ovan lägger vi till dom i vyn bara. 
        }

        private async void savebtn_Click(object sender, RoutedEventArgs e)
        {
            await saveStorageToFile();

            //Måste vi göra liknande som i customer med add(user) fast med produkter 

            //Store.Storage.Items(product); // Funkar ej. Detta är pga det är en dictionary. Det är inte de andra 

            MessageBox.Show("Storage saved");
        }

        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här listviewn?

        internal async Task saveStorageToFile() //Än så länge är denna inte färdig. Filen skapas men inget syns i filen. 
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Storage.json";

            using FileStream createStream = File.Create(path + fileNameStore);
            await JsonSerializer.SerializeAsync(createStream, StorageManager.ProductsInStock);
            await createStream.DisposeAsync();


            //Exempel nedan på hur vi kan spara dictionary till fil? 

            //using (StreamWriter file = new StreamWriter("Storage.json"));
            //foreach (var product in Store.Storage)
            //{  
            //    ("Key: {0}, Value: {1}", product.Key, product.Value);
            //}


            //var storage = new Store(); 


            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString = JsonSerializer.Serialize(storage, options);

        }


    }
}
