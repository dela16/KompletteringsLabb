using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class StorageManager
    {
        //Osäker om jag behöver ha med en storage manager...? Det kanske räcker med en storemanager och där i ha storage?

        public static Dictionary<Product, int> storage { get; set; } = new ();

        public static Store currentStorage { get; set; } = new();

        public static void initializeManager()
        {
            //storage.Add(new Store() { Name = "Denices Storage" });
            //currentStorage = storage[0];
        }
    }
}
