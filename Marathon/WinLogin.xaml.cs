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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        
        
        
        private void TxtLogin_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (TxtLogin.Text == "Адрес электронной почты")
            {
                TxtLogin.Clear();
                TxtLogin.Foreground = Brushes.Black;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtLogin.Text))
                {
                    TxtLogin.Foreground = Brushes.Gray;
                    TxtLogin.Text = "Адрес электронной почты";
                }
            }
        }
    }
}
