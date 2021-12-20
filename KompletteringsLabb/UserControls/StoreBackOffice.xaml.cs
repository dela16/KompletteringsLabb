using KompletteringsLabb.Models;
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
    /// Interaction logic for StoreBackOffice.xaml
    /// </summary>
    public partial class StoreBackOffice : UserControl
    {
        Product product = new Product();
        Store storage = new Store(); 
        public StoreBackOffice()
        {
            //InitializeComponent();
            //Store storage visar produkterna för varje enskild butik.
            //currentstore 
            ProductManager.products = ProductsToAdd.Items;
            StoreManager.currentStore.Storage = ProductsInStore.Items; // ProductManager.products; 

            //Har detta något med att att det är en datagrid? 
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
            StoreManager.currentStore.Storage.Add(test, 10); //Här tar vi testprodukten och lägger till den i vår storage för butiken. 
            //Borde vi inte vilja ha selectedItem = blablabla.Add()? 
            
        }

        //Här bör det finnas en metod som är kopplad till produkt klassen och en lista över olika produkter. 
        //En add metod som tar produkt från ena stället till det andra. 
        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här gridviewn?
        //Räkna ut antalet för varje kolumn samt kostnaden. Automatisk ändring. 

        
    }
}
