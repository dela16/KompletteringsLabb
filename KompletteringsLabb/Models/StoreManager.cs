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


        public static void initializeManager()
        {
            stores.Add(new Store() { Name = "Denices Hairsaloon" });
            currentStore = stores[0];
        }

    }
}
