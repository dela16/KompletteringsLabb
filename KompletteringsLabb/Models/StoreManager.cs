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
        public static Store CurrentStore { get; set; }

        public static void InitializeStoreManager()
        {
            Store store = new Store() { StoreName = "Denices Hairsalon" };
            Stores.Add(store);
            CurrentStore = store;
            //CurrentStore.customers.Add(CustomerManager.CurrentCustomer);//Nu finns det en kund som kan nå "sin" butik. 
            //CurrentStore.admin.Add(AdminManager.currentAdmin);
            
        }
    }
}
