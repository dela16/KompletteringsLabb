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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for NewAdminView.xaml
    /// </summary>
    public partial class NewAdminView : UserControl
    {
        public NewAdminView()
        {
            //AdminName.Text = 
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            AdminName.Clear();
            AdminPassword.Clear();
            StoreName.Clear();
        }

        private void CreateNewAdminbtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Store store = new Store(); 

            user.Name = AdminName.Text;
            user.Password = AdminPassword.Text;

            store.Name = StoreName.Text; 

            AdminManager.admins.Add(user);
            StoreManager.Stores.Add(store);

            if (AdminName.Text == "")
            {
                MessageBox.Show("You have to insert a username.");
            }
            else if (AdminPassword.Text == "")
            {
                MessageBox.Show("You have to insert a password.");
            }
            else if (StoreName.Text=="")
            {
                MessageBox.Show("You have to name your store.");
            }
            else 
            {
                StoreBackOffice.Visibility = Visibility.Visible;
                //Här vill vi spara till fil.
                //saveStoreToFile(); //Ska denna vara här? Ska jag ha en tredje fil att spara till? 
            }
        }

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
