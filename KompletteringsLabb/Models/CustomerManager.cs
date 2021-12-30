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

            //Juste, måste kunde välja vilken butik den vill handla i? 
            //Ha en lista med stores? 

        }

        //Den här hämtar listan med sparade kunder där jag sparade den. Ingen ruta poppar upp. 
        public static void LoadCustomersFromFile() 
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameCustomers = "Customers.json";

            using FileStream OpenStream = File.OpenRead(path + fileNameCustomers);
            Customers = JsonSerializer.DeserializeAsync<List<User>>(OpenStream).Result;

        }


        //Här väljer vi vilken fil vi ska öppna med kunder om jag vill välja det själv. 


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
