using KompletteringsLabb.Models;
using KompletteringsLabb.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KompletteringsLabb
{
    internal class Store
    {
        public User admin { get; set; } = new();
        public List<User> customers { get; set; } = new(); 

        public string Name { get; set; } //Butikens namn. Matcha den med admin. 

        public Dictionary<Product, int> Storage { get; set; } = new(); //butikens lager. Kopplad till vår produkt. int är antal!

        public void initializeStorage()
        {
            Storage.Add(new() { Name = "Hårgele", Price = 7 }, 10); //Denna funkar ej. 
            //Product är klassen med olika properties. Både Namn och pris ska vara i Product. Sedan antal för att det ska vara det enligt Dictionaryt. 
            //Här ska ju allt som finns i nuvarande butik finnas. Från BackOffice. 

        }


        public bool LogInAdmin(User user)//Varför kopplas inte den här till adminManager? Varför funkar inte min default? Är det för att den inte kopplas till admins?
        {
            if (admin.Name == user.Name)
            {
                if (admin.Password == user.Password)
                {
                    //Hur ta mig till rätt butik? Den känner av det från när du skapade nya användare
                    return true;
                }
            }
            return false;

        }

        public bool LogInUser(User user)
        {
            foreach (User customer in customers) 
            {
                if (customer.Name == user.Name && customer.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task CheckOut(User kund)
        {
            MessageBox.Show("Payment Succeeded!");
        }
    }
}