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
            CustomerName.Clear(); //Om vi börjat skriva något och går tillbaka så raderas detta. 
            CustomerPassword.Clear();
        }

        private async void CreateCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.Name = CustomerName.Text;
            user.Password = CustomerPassword.Text;


            if (CustomerName.Text == "") //eller borde vi först hänvisa till user.Name?
            {
                MessageBox.Show("You must have a Username");
            }
            else if (CustomerPassword.Text == "")
            {
                MessageBox.Show("Not a validate password");
            }
            else {
                CustomerProfileView.Visibility = Visibility.Visible;
                //await SaveCustomersToFile();//Denna tror jag inte fungerar helt ännu... (Se dokumentet) 
            }; 
            //Denna går såklart att avancera med fler villkor men vi börjar här. 

            CustomerManager.Customers.Add(user);
            //Sparas till fil, nu asynkromt


        }

        internal static async Task SaveCustomersToFile()
        {
            User user = new User();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //men vi ska spara dom till två olika mappar. Hur? 
            string fileNameCustomers = "Customers.json";


            using FileStream createStream = File.Create(path + fileNameCustomers); //fullPath ska vara path + filnamn, typ Path.Combine(*path*, *filename*)
            await JsonSerializer.SerializeAsync(createStream, user);
            await createStream.DisposeAsync();
           
        }
    }
}
