using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class AdminManager
    {
        public static List<User> Admins { get; set; } = new();
        public static User CurrentAdmin { get; set; } = new(); 

        public static void InitilizeAdminManager()
        {
            User admin = new User() { Name = "Denice", Password = "denice" };
            Admins.Add(admin);
            CurrentAdmin = admin;
        }
    }
}
