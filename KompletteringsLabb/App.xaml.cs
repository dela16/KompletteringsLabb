using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KompletteringsLabb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        public App()
        {
            StoreManager.InitializeStoreManager();
            ProductManager.InitializeProductManager();
            CustomerManager.InitializeCustomerManager();
            AdminManager.InitilizeAdminManager();
        }

    }
}
