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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marathon
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);

        }

        private void BtnBecomeRunner_Click(object sender, RoutedEventArgs e)
        {
            
            new WinRegAsRunner().Show();
            this.Close();
        }

        private void BtnBecomeSponsor_Click(object sender, RoutedEventArgs e)
        {
            new WinSponsor().Show();
            Close();
        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }

        private void BtnLoginPg_Click(object sender, RoutedEventArgs e)
        {
            
            new WinLogin().Show();
            Close();
        }
       
    }
}
