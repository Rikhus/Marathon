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
    /// Логика взаимодействия для WinSponsorThanks.xaml
    /// </summary>
    public partial class WinSponsorThanks : Window
    {
        public WinSponsorThanks()
        {
            InitializeComponent();
            LblRunner.Content = LocalStorage.SelectedRunnerForSponsorShip.Runner;
            lblCharityName.Content = LocalStorage.SelectedRunnerForSponsorShip.CharityName;
            LblAmount.Content = "$" + LocalStorage.SelectedRunnerForSponsorShip.Amount.ToString();
            LocalStorage.TimeCalc(LblTime);
        }

       

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
           
            Close();
        }
    }
}
