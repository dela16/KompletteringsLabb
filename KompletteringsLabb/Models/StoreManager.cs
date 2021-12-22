using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    static class StoreManager
    {
        public static List<Store> Stores { get; set; } = new List<Store>();

        public static Store CurrentStore { get; set; } = new();

        public static void initializeStore()
        {
            Stores.Add(new Store() { Name = "Denices Hairsalon" });
            CurrentStore = Stores[0];
        }
    }
}
