using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    public class ProductStock
    {
        public Product Product { get; set; }
        public double Stock { get; set; }

        public double Total { get; set; }
    }
}
