using KompletteringsLabb.UserControls;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    public class ProductManager
    {   //DET HÄR ÄR LISTAN ÖVER ALLA PRODUKTER. 
        //cLASSEN PRODUCT VISAR VAD DEN SKA HA FÖR ATTRIBUT! 
        //ProductManager måste matcha rätt butiksnamn

        public static List<Product> products { get; set;} = new List<Product>();

        public static List<Product> GetProducts()
        {
            return products;
        }
        public static void InitializeProductManager()
        {
            products.Add(new Product() { Name = "HårDenice", Price = 39 }); //just nu får jag bara fram denna i min vy
            products.Add(new Product() { Name = "Gel", Price = 89 });
            products.Add(new Product() { Name = "HairColor", Price = 169 });
            products.Add(new Product() { Name = "Mousse", Price = 79 });



        }

    }
}
