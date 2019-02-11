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
    /// Логика взаимодействия для WinMoreInfo.xaml
    /// </summary>
    public partial class WinMoreInfo : Window
    {
        public WinMoreInfo()
        {
            InitializeComponent();
            TimeCalc();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        public void TimeCalc()
        {
            DateTime startTime = new DateTime(2019, 9, 21);
            DateTime now = DateTime.Now;
            TimeSpan span = startTime.Subtract(now);
            LblTime.Content = "Осталось " + span.Days + " дней " + span.Hours + " часов " + span.Minutes + " минут.";
        }

        private void BtnCharityInf_Click(object sender, RoutedEventArgs e)
        {
            new WinCharityList().Show();
            Close();
        }
    }
}
