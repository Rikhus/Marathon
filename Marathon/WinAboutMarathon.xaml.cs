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
    /// Логика взаимодействия для WinAboutMarathon.xaml
    /// </summary>
    public partial class WinAboutMarathon : Window
    {
        public WinAboutMarathon()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInf().Show();
            Close();

        }

        private void BtnMap_Click(object sender, RoutedEventArgs e)
        {
            new WinMarathonMap().Show();
            Close();
        }
    }
}
