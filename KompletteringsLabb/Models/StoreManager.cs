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

        public static void InitializeStoreManager()
        {
            Stores.Add(new Store() { Name = "Denices Hairsalon" });
            CurrentStore = Stores[0];
            CurrentStore.customers.Add(CustomerManager.currentCustomer);//Nu finns det en kund som kan nå "sin" butik. 
            //CurrentStore.admin.Add(AdminManager.currentAdmin);
        }
    }
}
