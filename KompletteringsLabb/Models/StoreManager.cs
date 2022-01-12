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
            Store store = new Store() { StoreName = "Denice Icabutik" };
            Stores.Add(store);
            CurrentStore = store;
            //CurrentStore.customers.Add(CustomerManager.CurrentCustomer);
            //CurrentStore.admin.Add(AdminManager.currentAdmin);
            
        }
    }
}
