using KompletteringsLabb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace KompletteringsLabb.UserControls
{
    /// <summary>
    /// Interaction logic for NewAdminView.xaml
    /// </summary>
    public partial class NewAdminView : UserControl
    {
        public NewAdminView()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            AdminName.Clear();
            AdminPassword.Clear();
        }

        private async void CreateNewAdminbtn_Click(object sender, RoutedEventArgs e)
        {
            User admin = new User();

            admin.Name = AdminName.Text;
            admin.Password = AdminPassword.Text;

            AdminManager.Admins.Add(admin);

            if (AdminName.Text == "" || AdminName.Text == " ")
            {
                MessageBox.Show("Not a valid username.");
            }
            else if (AdminPassword.Text == ""|| AdminPassword.Text == " ")
            {
                MessageBox.Show("Not a valid password.");
            }
            else
            {
                MessageBox.Show("new admin saved.");
                //Här vill vi spara till fil.
                await saveAdminToFile();
                Visibility = Visibility.Collapsed;

                AdminManager.Admins.Add(admin); 

                AdminName.Clear(); //Om vi går vidare så ska den clearas.  
                AdminPassword.Clear();
            }
        }

        internal async Task saveAdminToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileNameStore = "Admin.json";

            using FileStream createStream = File.Create(path + fileNameStore); 
            await JsonSerializer.SerializeAsync(createStream, AdminManager.Admins);
            await createStream.DisposeAsync();

        }
    }
}
