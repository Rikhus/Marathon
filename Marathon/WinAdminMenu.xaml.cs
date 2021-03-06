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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinAdminMenu.xaml
    /// </summary>
    public partial class WinAdminMenu : Window
    {
        public WinAdminMenu()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnInventory_Click(object sender, RoutedEventArgs e)
        {
            new WinInventory().Show();
            Close();
        }

        private void BtnCharityManage_Click(object sender, RoutedEventArgs e)
        {
            new WinCharitiesManage().Show();
            Close();
        }

        private void BtnVolunteer_Click(object sender, RoutedEventArgs e)
        {
            new WinVolunteers().Show();
            Close();
        }
    }
}
