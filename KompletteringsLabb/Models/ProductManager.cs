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

        public List<Product> products { get; set; } = new List<Product>();

        public List<Product> GetProducts()
        {
            products.Add(new Product() { Name = "Hairspray", Price = 39 });
            products.Add(new Product() { Name = "Gel", Price = 89 });
            products.Add(new Product() { Name = "HairColor", Price = 169 });
            products.Add(new Product() { Name = "Mousse", Price = 79 });
            return products; 
        }
        public ProductManager() //Det här är den vänstra vyn i Backoffice. //Detta är default läge för oss
        {
            
        }
 

    }
}
