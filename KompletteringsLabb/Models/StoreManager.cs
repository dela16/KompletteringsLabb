using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class StoreManager
    {
        public static List<Store> stores { get; set; } = new List<Store>();

        public StoreManager() //Defaultlista över butiker. 
        {
            stores.Add( new Store() { Name = "Denices Hairsaloon" });
        }

    }
}
