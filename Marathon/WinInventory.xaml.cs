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
    /// Логика взаимодействия для WinInventory.xaml
    /// </summary>
    public partial class WinInventory : Window
    {
        public WinInventory()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinAdminMenu().Show();
            Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            new WinInvReport().Show();
        }

        private void BtnArrival_Click(object sender, RoutedEventArgs e)
        {
            new WinArrival().Show();
            Close();
        }
    }
}
