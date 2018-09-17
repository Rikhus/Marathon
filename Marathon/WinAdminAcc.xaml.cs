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
using System.Data.Entity;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinAdminAcc.xaml
    /// </summary>
    public partial class WinAdminAcc : Window
    {
      
        public WinAdminAcc()
        {
            InitializeComponent();loadTime();
        }
        //метод отсчета и вывода оставшегося до окончания марафона времени
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
        }
        //кнопка возврата на главную страницу
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show(); Close();
        }
        //кнопка выхода из аккаунта
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show(); Close();
        }
       
    }
}