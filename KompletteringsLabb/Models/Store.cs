using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompletteringsLabb
{

    class Store
    {
       public string Name { get; set; } = new();
        public Dictionary<Product, int> Storage { get; set; } = new();
        public User Admin { get; set; } = new (); 
    }

    public bool LogInAdmin(User user)
    //{
    //    //Då detta är en bool så måste svaret blir true eller false. Betyder det att det finns olika admins för olika butiker? 
    //    //Det är något jag tänker fel, kanske kopplingen mellan classer och UC
    //DEnna metoden kan ju anorpas från en annan metod. Niklas tror att det kan vara enklare att ha flera butiker. 

    //    //Om Login för admin är successfull then
    //StoreBackOffice.Visibility = Visibility.visible;

    //Om UserName eller Password = false then 
    //Kolla med listorna över sparade användare.
    //MessageBox.Show("Incorrect UserName or Password, Please try again.");
    ////else 
    //AdminLoginView.Visibility = Visibility.Collapsed;

}


    //public async Task CheckOut(User kund)
    //{

    //}
}
