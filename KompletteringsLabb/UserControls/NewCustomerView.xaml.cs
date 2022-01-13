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
        
        public NewCustomerView()
        {
            InitializeComponent();
        }
        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            CustomerName.Clear();
            CustomerPassword.Clear();
        }

        private async void CreateCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.Name = CustomerName.Text;
            user.Password = CustomerPassword.Text;


            if (CustomerName.Text == "" || CustomerName.Text == " ")
            {
                MessageBox.Show("You must have a Username");
                return;
            }
            else if (CustomerPassword.Text == "" || CustomerPassword.Text == " ")
            {
                MessageBox.Show("Not a valid password");
                return;
            }
            else
            {
                Visibility = Visibility.Collapsed;
                //await SaveCustomersToFile();

                CustomerManager.Customers.Add(user);

                //Sparas till fil, nu asynkromt
                await SaveCustomersToFile();
                MessageBox.Show("Customer saved");

                CustomerName.Clear();
                CustomerPassword.Clear();
            }

        }
        
        internal static async Task SaveCustomersToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); 
            string fileNameCustomers = "Customers.json";

            //Här sparar vi till fil. Vi skapar ny fil med varje ny kund och "inte" lägger till. 
            using FileStream createStream = File.Create(path + fileNameCustomers); 
            await JsonSerializer.SerializeAsync(createStream, CustomerManager.Customers);
            await createStream.DisposeAsync();

        }

    }
}
