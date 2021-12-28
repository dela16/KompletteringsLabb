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
    /// Interaction logic for NewAdminView.xaml
    /// </summary>
    public partial class NewAdminView : UserControl
    {
        public NewAdminView()
        {
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
                //Här vill vi spara till fil.
                saveStoreToFile();
                AdminLoginView.Visibility = Visibility.Visible; //Här ville niklas att vi ska tas tillbaka till loginvyn för admin. 
            }
        }

        internal async Task saveStoreToFile()
        {
            Store store = new Store();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Store.json";

            using FileStream createStream = File.Create(path + fileNameStore); 
            await JsonSerializer.SerializeAsync(createStream, store);
            await createStream.DisposeAsync();
        }
    }
}
