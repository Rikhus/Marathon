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
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        

        private void BtnCharityInf_Click(object sender, RoutedEventArgs e)
        {
            new WinCharityList().Show();
            Close();
        }

        private void BtnHowLongMar_Click(object sender, RoutedEventArgs e)
        {
            new WinHowLongIsMarathon().Show();
            Close();
        }

        private void BtnAboutMar_Click(object sender, RoutedEventArgs e)
        {
            new WinAboutMarathon().Show();
            Close();
        }
    }
}
