using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    static class CustomerManager
    {

        public static List<User> Customers { get; set; } = new();

        public static User CurrentCustomer { get; set; } = new();

        public static void InitializeCustomerManager() //Denna är vår default lista. 
        {
            LoadCustomersFromFile();
            //Customers.Add(new User() {Name="DeniceML", Password="DenicePassword" });

        }

        
        public static void LoadCustomersFromFile() //Den här hämtar listan med sparade kunder.
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameCustomers = "Customers.json";

            using FileStream OpenStream = File.OpenRead(path + fileNameCustomers);
            Customers = JsonSerializer.DeserializeAsync<List<User>>(OpenStream).Result;

        }


        //Koden nedan är en slags "pop-up" som kommer upp. Om jag avkommenterar den då kommer den köras när jag kallar på den. 
        //Men jag vill inte ha den så därför är den utkommenterad. 


        //private static void LoadOpenFileDialogForCustomers() 
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        using FileStream OpenStream = File.OpenRead(openFileDialog.FileName);
        //        Customers = JsonSerializer.DeserializeAsync<List<User>>(OpenStream).Result;
        //    }
        //}
    }
}
