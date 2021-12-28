using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class AdminManager
    {
        public static List<User> admins { get; set; } = new();
        public static User currentAdmin { get; set; } = new(); 

        public static void InitilizeAdminManager()
        {
            admins.Add(new User() {Name = "Denice", Password="denice"});
            currentAdmin = admins[0];
        }
    }
}
