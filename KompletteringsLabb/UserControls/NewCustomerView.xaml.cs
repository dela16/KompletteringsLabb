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
            Visibility = Visibility.Collapsed;
                //await SaveCustomersToFile();//Denna tror jag inte fungerar helt ännu... (Se dokumentet) 
            };
            //Denna går såklart att avancera med fler villkor men vi börjar här. 

            CustomerManager.customers.Add(user);




            //Sparas till fil, nu asynkromt
            await SaveCustomersToFile();
            MessageBox.Show("Customer saved");

            CustomerName.Clear(); //Om vi går vidare så ska den clearas.  
            CustomerPassword.Clear();

        }


        
        internal static async Task SaveCustomersToFile()
        {


            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //men vi ska spara dom till två olika mappar. Hur? 
            string fileNameCustomers = "Customers.json";

            //Den här har inte funkat hittills. Har jag en lista att spara till ens? 
            //using FileStream createStream = File.Create(path + fileNameCustomers); //fullPath ska vara path + filnamn, typ Path.Combine(*path*, *filename*)
            //await JsonSerializer.SerializeAsync(createStream, user);
            //await createStream.DisposeAsync();

            ////Labb3 test
            //using StreamWriter streamWriter = new(Path.Combine(path,fileNameCustomers));
            //await streamWriter.WriteAsync(JsonSerializer.Serialize(user)); 

            //Niklas lektion
            //StreamWriter writer = new StreamWriter(path);
            //writer.Dispose();

            //using (var writer = new StreamWriter(path))
            //{

            //}
        }
    }
}
