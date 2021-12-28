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
            //Customers.Add(new User() {Name="DeniceML", Password="DenicePassword" });
            //currentCustomer = customers[0];

            //Juste, måste kunde välja vilken butik den vill handla i? 
            //Ha en lista med stores? 


            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog()==true)
            {
                using FileStream OpenStream = File.OpenRead(openFileDialog.FileName);
                CustomerManager.Customers = JsonSerializer.DeserializeAsync<List<User>>(OpenStream).Result; 
            }

        }
    }
}
