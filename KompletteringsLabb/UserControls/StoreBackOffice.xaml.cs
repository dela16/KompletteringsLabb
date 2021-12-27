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


            //ProductManager.products = ProductsToAdd.Items;
            //StoreManager.currentStore.Storage = ProductsInStore.Items; // ProductManager.products; 

            //saveStoreToFile(); 
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            //Lägg till nya produkten i ProductsInStore. 
            //Behöver vi en lista där vi som användare kan lägga till saker även i ProductsToAdd?
            //Kolla Store klassen och hur allt ska kopplas. '

            var test = new Product();
            test.Name = "Wax";
            test.Price = 70;
            StoreManager.CurrentStore.Storage.Add(test, 10); //Här tar vi testprodukten och lägger till den i vår storage för butiken. 

            Product newProduct = new Product();

            //Pop-up ruta där man frågar hur många man vill lägga till? 
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
