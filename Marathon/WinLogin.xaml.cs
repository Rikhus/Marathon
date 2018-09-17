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
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        public WinLogin()
        {
            InitializeComponent(); 
        }
        //кнопка возврата на главную страницу
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        
        //кнопка выбора аккаунта бегуна
        private void BtnSelRunner_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerAcc().Show();
            Close();
            this.Owner.Close();
            
        }
        //кнопка выбора аккаунта бегуна
        private void BtnSelAdmin_Click(object sender, RoutedEventArgs e)
        {
            new WinAdminAcc().Show();
            Close();
            this.Owner.Close();
        }

        private void BtnSelCoordinator_Click(object sender, RoutedEventArgs e)
        {
            new WinCoordinatorAcc().Show();
            Close();
            this.Owner.Close();
        }
    }
}
