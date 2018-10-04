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
    /// Логика взаимодействия для WinMoreInf.xaml
    /// </summary>
    public partial class WinMoreInf : Window
    {
        public WinMoreInf()
        {
            InitializeComponent(); loadTime();
        }
        //кнопка возврата на главный экран
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        //метод отсчеча времени до конца марафона
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
            
        }

        private void BtnMarathon_Click(object sender, RoutedEventArgs e)
        {
            new WinAboutMarathon().Show();
            Close();
        }

        private void BtnPrevRes_Click(object sender, RoutedEventArgs e)
        {
            new WinPrevRes().Show();
            Close();
        }

        private void BtnBMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCharityInf_Click(object sender, RoutedEventArgs e)
        {
            new WinCharityInf().Show(); Close();
        }
    }
}
