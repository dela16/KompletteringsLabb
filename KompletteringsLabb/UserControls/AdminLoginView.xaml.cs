﻿using System;
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
    /// Interaction logic for AdminLoginView.xaml
    /// </summary>
    public partial class AdminLoginView : UserControl
    {
        public AdminLoginView()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed; 
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            Store.LogInAdmin();
            
        }
    }
}
