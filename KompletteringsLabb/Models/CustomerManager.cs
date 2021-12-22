using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    static class CustomerManager
    {

        public static List<User> customers { get; set; } = new();

        public static User currentCustomer { get; set; } = new();

        public static void InitializeCustomerManager() //Denna är vår default lista. 
        {
            customers.Add(new User() {Name="DeniceML", Password="DenicePassword" });
            currentCustomer = customers[0];

            //Juste, måste kunde välja vilken butik den vill handla i? 
            //Ha en lista med stores? 
        }
    }
}
