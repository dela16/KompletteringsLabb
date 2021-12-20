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

        public string Name { get; set; } //Butikens namn. Matcha den med admin. 

        public Dictionary<Product, int> Storage { get; set; } = new(); //butikens lager. Kopplad till vår produkt. int är antal!

        public bool LogInAdmin(User user)
        {
            if (admin.Name == user.Name)
            {
                if (admin.Password == user.Password)
                {
                    //Om Login för admin är successfull then
                    // 
                    //Hur ta mig till rätt butik? Den känner av det från när du skapade nya användare
                    return true;
                }
            }
            return false;

        }

        //public async Task CheckOut(User kund)
        //{

        //}
    }
}