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
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        //Här bör det finnas en metod som är kopplad till produkt klassen och en lista över olika produkter. 
        //En add metod som tar produkt från ena stället till det andra. 
        //Avancera så pass att när kunden köper en produkt så ska antalet minska i den här gridviewn?
        //Räkna ut antalet för varje kolumn samt kostnaden. Automatisk ändring. 
    }
}
