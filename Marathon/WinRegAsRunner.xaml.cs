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
    
    public partial class WinRegAsRunner : Window
    {
        public WinRegAsRunner()
        {
            InitializeComponent();
            TimeCalc();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnLoginPg_Click(object sender, RoutedEventArgs e)
        {
            new WinLogin().Show();
            Close();
        }

        private void BtnPartEarlier_Click(object sender, RoutedEventArgs e)
        {
            new WinLogin().Show();
            Close();
        }

        private void BtnNewPart_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerReg().Show();
            Close();
        }
        public void TimeCalc()
        {
            DateTime startTime = new DateTime(2019, 9, 21);
            DateTime now = DateTime.Now;
            TimeSpan span = startTime.Subtract(now);
            LblTime.Content = "Осталось " + span.Days + " дней " + span.Hours + " часов " + span.Minutes + " минут.";
        }
    }
}
