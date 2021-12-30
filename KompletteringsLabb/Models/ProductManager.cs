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

        public static List<Product> Products { get; set;} = new List<Product>();

        public static void InitializeProductManager()
        {
            Products.Add(new Product() { Name = "Gel", Price = 89 });
            Products.Add(new Product() { Name = "HårDenice", Price = 39 }); 
            Products.Add(new Product() { Name = "HairColor", Price = 169 });
            Products.Add(new Product() { Name = "Mousse", Price = 79 });
            Products.Add(new Product() { Name = "RayBan sunglasses, black", Price = 1057 });
            Products.Add(new Product() { Name = "RayBan sunglasses, kids - green", Price = 699 });
            Products.Add(new Product() { Name = "Svantes eyewear", Price = 57 });
            Products.Add(new Product() { Name = "Dior parfume", Price = 999 });
            Products.Add(new Product() { Name = "Hugo Boss - The one", Price = 1083 });
            Products.Add(new Product() { Name = "Barbies sweet, sweet smell", Price = 159 });
            Products.Add(new Product() { Name = "Ken's cool carsmell", Price = 287 });
            Products.Add(new Product() { Name = "Mamma Scans julskinka", Price = 49 });
            Products.Add(new Product() { Name = "Pappa Patos köttbullar", Price = 73 });
            Products.Add(new Product() { Name = "Familjen Larsons favoritostar", Price = 391 });
            Products.Add(new Product() { Name = "Los Latinos - Tacokrydda", Price = 21 });

        }

    }
}
