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

        public static Dictionary<Product, int> storage { get; set; } = new(); //Ska denna och raden under vara här eller i storage manager. Tror den ska vara där? 
        //Men länkas dom samman då? 
        public static Store currentStorage { get; set; } = new(); 

        public static void initializeStore()
        {
            stores.Add(new Store() { Name = "Denices Hairsalon" });
            currentStore = stores[0];

            //storage.Add(new Store() {Product ="Hårgele" });
            //currentStorage = storage[0];
        }

    }
}
