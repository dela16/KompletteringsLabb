﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb.Models
{
    class AdminManager
    {
        public static List<User> admins { get; set; } = new();

        public AdminManager()
        {
            admins.Add(new User() {Name = "Denice", Password="denice"});

        }
    }
}