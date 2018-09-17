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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); loadTime();
        }
        //кнопка для регистрации в системе
        private void BtnMoreInf_Click(object sender, RoutedEventArgs e)
        { new WinMoreInf().Show(); Close(); }
        //кнопка меню бегуна
        private void BtnRunner_Click(object sender, RoutedEventArgs e)
        {
            new WinRinnerMenu().Show();
            Close();
        }
        //кнопка для перехода в меню входа
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            new WinFullLogin().Show();
            Close();
        }
        //метод для отсчета времени
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
        }
    }
}
