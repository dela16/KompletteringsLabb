using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Data;
using System.IO;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for NewCustomerView.xaml
    /// </summary>
    public partial class NewCustomerView : UserControl
    {
        string storePath = "Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)";
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //men vi ska spara dom till två olika mappar. Hur? 
        string fileNameCustomers = "Customers.json";
        string fileNameStore = "Store.json"; 
        

        public NewCustomerView()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void CreateCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.Name = CustomerName.Text;
            user.Password = CustomerPassword.Text;

            //if (CustomerName.Text = " ")
            //{
            //    MessageBox.Show("Not a validate username");
            //}

            CustomerManager.Customers.Add(user);
            //Sparas till fil, nu asynkromt
            SaveToFile();
            

            CustomerProfileView.Visibility = Visibility.Visible; 

        }

        internal static async Task SaveToFile()
        {
            User user = new User();

            using FileStream createStream = Path.Combine(userPath, fileNameUsers); //fullPath ska vara path + filnamn, typ Path.Combine(*path*, *filename*)
            await JsonSerializer.SerializeAsync(createStream, user);
            await createStream.DisposeAsync();
            
            //string jsonString = JsonSerializer.Serialize(user);
            //File.WriteAllText(fileNameUsers, jsonString);

            //using StreamWriter streamWriter = new(Path.Combine(userPath, fileNameUsers));
            //string jsonString = JsonSerializer.Serialize(user);
            //await streamWriter.WriteAsync(jsonString);
        }
    }
}
