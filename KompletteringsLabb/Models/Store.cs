﻿using KompletteringsLabb.Models;
using KompletteringsLabb.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KompletteringsLabb
{
    internal class Store
    {
        public User admin { get; set; } = new();

        public string Name { get; set; } //Butikens namn. Matcha den med admin. 

        public Dictionary<Product, int> Storage { get; set; } = new();

        public bool LogInAdmin(User user) 
        {
            if (admin.Name = AdminLoginView.AdminName.Text)
            {
                if (admin.Password = AdminLoginView.AdminPassword.Text)
                {
                    //Om Login för admin är successfull then
                    StoreBackOffice.Visibility = Visibility.visible;
                    //Hur ta mig till rätt butik? 
                }
                MessageBox.Show("Incorrect UserName or Password, Please try again.");
            }

        } //Vi ska jämföra användarnamn med rätt butik. 


    //Om UserName eller Password = false then 
    //Kolla med listorna över sparade användare.
    //MessageBox.Show("Incorrect UserName or Password, Please try again.");
    ////else 
    //AdminLoginView.Visibility = Visibility.Collapsed;

    //public async Task CheckOut(User kund)
    //{

    //}
}
}