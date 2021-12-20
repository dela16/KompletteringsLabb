using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for NewAdminView.xaml
    /// </summary>
    public partial class NewAdminView : UserControl
    {
        public NewAdminView()
        {
            //AdminName.Text = 
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void CreateNewAdminbtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Store store = new Store(); 

            user.Name = AdminName.Text;
            user.Password = AdminPassword.Text;

            store.Name = StoreName.Text; 

            AdminManager.admins.Add(user);
            StoreManager.stores.Add(store);
            //Här vill vi spara till fil.

            StoreBackOffice.Visibility = Visibility.Visible;

        }
    }
}
