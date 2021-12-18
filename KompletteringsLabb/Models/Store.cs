using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb
{
    internal class Store
    {
        private User admin = new(); //Har jag gort fel nu pga denna? Jag vill ju ha en databas över mina admins också

        public Dictionary<Product, int> Storage { get; set; } = new();
        //public bool LogInAdmin(User user) { }
        //{
        //DEnna metoden kan ju anorpas från en annan metod. Niklas tror att det kan vara enklare att ha flera butiker. 

        //    //Om Login för admin är successfull then
        //StoreBackOffice.Visibility = Visibility.visible;

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