using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    static class StoreManager
    {
        public static List<Store> stores { get; set; } = new List<Store>();

        public static Store currentStore { get; set; } = new();

        public static Dictionary<Product, int> storage { get; set; } = new();
        public static Store currentStorage { get; set; } = new(); 

        public static void initializeManager()
        {
            stores.Add(new Store() { Name = "Denices Hairsalon" });
            currentStore = stores[0];

            //storage.Add(new Store() {Name =" Denices Storage" });
            //currentStorage = storage[0];
        }

    }
}
