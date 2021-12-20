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
        public StoreBackOffice()
        {
            //InitializeComponent();

            //ProductsToAdd.ItemsSource = ProductManager.products; 
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            //Lägg till nya produkten i ProductsInStore. 
            //Behöver vi en lista där vi som användare kan lägga till saker även i ProductsToAdd?
            //Kolla Store klassen och hur allt ska kopplas. 
            //Lägger du till produkter i Store klassen eller via din productManager? 
            //Eller är productmanager bara listan över produkter och när du lägger till i affären så anvädner du din Store? 

            
        }

        //Här bör det finnas en metod som är kopplad till produkt klassen och en lista över olika produkter. 
        //En add metod som tar produkt från ena stället till det andra. 
        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här gridviewn?
        //Räkna ut antalet för varje kolumn samt kostnaden. Automatisk ändring. 

        
    }
}
