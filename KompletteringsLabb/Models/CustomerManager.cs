using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class CustomerManager
    {

        public static List<User> Customers { get; set; } = new(); 

        public CustomerManager() //Denna är vår default lista. 
        {
            Customers.Add(new User() {Name="DeniceML", Password="DenicePassword" });
        }
    }
}
