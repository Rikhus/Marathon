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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinRinnerMenu.xaml
    /// </summary>
    public partial class WinRinnerMenu : Window
    {
        public WinRinnerMenu()
        {
            InitializeComponent(); loadTime();
        }

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
            new MainWindow().Show();
            Close();
        }
        //кнопка для перехода на экран авторизации
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            new WinFullLogin().Show();
            Close();
        }
        //кнопка для подтверждения участия
        private void BtnParticEarlier_Click(object sender, RoutedEventArgs e)
        {
            new WinFullLogin().Show();
            Close();
        }

        private void BtnNewRunner_Click(object sender, RoutedEventArgs e)
        {
            new WinRegistration().Show(); Close();
        }
    }
}
