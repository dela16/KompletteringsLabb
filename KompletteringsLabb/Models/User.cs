using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class User
    {
        public string Name { get; set; }
        public List<ProductStock> Cart { get; set; } = new(); 
        public string Password { get; set; }

    }
}
