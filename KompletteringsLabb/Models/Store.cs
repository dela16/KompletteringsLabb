using KompletteringsLabb.Models;
using KompletteringsLabb.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace KompletteringsLabb
{
    internal class Store
    {
        public User Admin { get; set; } = new();

        public string StoreName { get; set; } //Butikens namn. Matcha den med admin. 
        public List<ProductStock> Storage { get; set; } = new List<ProductStock>(); //butikens lager. 

        public Store()
        {
            LoadStorageFromFile();
        }

        public bool LogInAdmin(User inputadmin)//Varför kopplas inte den här till adminManager? Varför funkar inte min default? Är det för att den inte kopplas till admins?
        {

            foreach (User admin in AdminManager.Admins)
            {
                if (admin.Name == inputadmin.Name && admin.Password == inputadmin.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LogInUser(User user)
        {
            foreach (User customer in CustomerManager.Customers) 
            {
                if (customer.Name == user.Name && customer.Password == user.Password)
                {
                    CustomerManager.CurrentCustomer = customer; //Här blir den inloggade använderen CurrentCustomer. Gå till CustomerLoginView för nästa steg.
                    return true;
                }
            }
            return false;

        }

        public void LoadStorageFromFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameCustomers = "Storage.json";

            using FileStream OpenStream = File.OpenRead(path + fileNameCustomers);
            Storage = JsonSerializer.DeserializeAsync<List<ProductStock>>(OpenStream).Result;
            
        }

        public async Task CheckOut(User kund)
        {
            MessageBox.Show("Payment Succeeded!");
        }
    }
}