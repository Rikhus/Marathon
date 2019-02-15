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
    /// Логика взаимодействия для WinRunnerMenu.xaml
    /// </summary>
    public partial class WinRunnerMenu : Window
    {
        public WinRunnerMenu()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnContacts_Click(object sender, RoutedEventArgs e)
        {
            new WinContacts().Show();
        }

        private void BtnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerProfileEdit().Show();
            Close();
        }
    }
}
