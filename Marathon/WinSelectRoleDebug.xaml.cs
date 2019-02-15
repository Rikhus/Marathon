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
    /// Логика взаимодействия для WinSelectRoleDebug.xaml
    /// </summary>
    public partial class WinSelectRoleDebug : Window
    {
        public WinSelectRoleDebug()
        {
            InitializeComponent();
        }

        private void BtnRunner_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            this.Owner.Close();
            this.Close();
        }

        private void BtnAsCoord_Click(object sender, RoutedEventArgs e)
        {
            new WinCoordinatorMenu().Show();
            this.Owner.Close();
            this.Close();
        }

        private void BtnAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            new WinAdminMenu().Show();
            this.Owner.Close();
            this.Close();
        }
    }
}
