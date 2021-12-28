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
            products.Add(new Product() { Name = "HårDenice", Price = 39 }); 
            products.Add(new Product() { Name = "Gel", Price = 89 });
            products.Add(new Product() { Name = "HairColor", Price = 169 });
            products.Add(new Product() { Name = "Mousse", Price = 79 });
            products.Add(new Product() { Name = "RayBan sunglasses, black", Price = 1057 });
            products.Add(new Product() { Name = "RayBan sunglasses, kids - green", Price = 699 });
            products.Add(new Product() { Name = "Svantes eyewear", Price = 57 });
            products.Add(new Product() { Name = "Dior parfume", Price = 999 });
            products.Add(new Product() { Name = "Hugo Boss - The one", Price = 1083 });
            products.Add(new Product() { Name = "Barbies sweet, sweet smell", Price = 159 });
            products.Add(new Product() { Name = "Ken's cool carsmell", Price = 287 });
            products.Add(new Product() { Name = "Mamma Scans julskinka", Price = 49 });
            products.Add(new Product() { Name = "Pappa Patos köttbullar", Price = 73 });
            products.Add(new Product() { Name = "Familjen Larsons favoritostar", Price = 391 });
            products.Add(new Product() { Name = "Los Latinos - Tacokrydda", Price = 21 });

        }

    }
}
