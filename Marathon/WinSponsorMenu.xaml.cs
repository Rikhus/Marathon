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
    /// Логика взаимодействия для WinSponsorMenu.xaml
    /// </summary>
    public partial class WinSponsorMenu : Window
    {
        public WinSponsorMenu()
        {
            InitializeComponent(); loadTime();TxtAmount.Text = "50"; LblAmount.Content ="$"+TxtAmount.Text; 
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        //метод отсчета времени
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            if (Int32.TryParse(TxtAmount.Text, out amount))
            {
                amount -= 1;
            }
            LblAmount.Content = "$" + amount.ToString();
            TxtAmount.Text = amount.ToString();
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            if (Int32.TryParse(TxtAmount.Text, out amount))
            {
                amount += 1;
            }
            LblAmount.Content = "$" + amount.ToString();
            TxtAmount.Text = amount.ToString();

        }

        private void TxtAmount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if ((string)LblAmount.Content != TxtAmount.Text)
            {
                LblAmount.Content = "$" + TxtAmount.Text;
            }
        }
    }
}
