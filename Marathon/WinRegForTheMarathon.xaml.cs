using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WinRegForTheMarathon.xaml
    /// </summary>
    public partial class WinRegForTheMarathon : Window
    {
         
        int Money=0;

        public IOrderedEnumerable<Charity> Charities { get; set; }

        public WinRegForTheMarathon()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadCharity();
        }

        public void LoadCharity()
        {
            using (var db = new MarathonDBEntities1())
            {
                Charities = db.Charity.ToList().OrderBy(u=> u.CharityName);
                CmbCharity.ItemsSource = Charities;
                CmbCharity.DisplayMemberPath = "CharityName";
                CmbCharity.SelectedValuePath = "CharityId";
                CmbCharity.SelectedIndex = 0;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void ChkFull_Checked(object sender, RoutedEventArgs e)
        {
            Money += 145;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void ChkFull_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 145;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void ChkHalf_Checked(object sender, RoutedEventArgs e)
        {
            Money += 75;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void ChkHalf_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 75;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void ChkSmall_Checked(object sender, RoutedEventArgs e)
        {
            Money += 20;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void ChkSmall_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 20;
            LblMoney.Content = "$" + Money.ToString();
        }

        private void Rdbtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Name == "RdbtnA")
            {

            }
            if (pressed.Name == "RdbtnB")
            {
                Money += 20;
                LblMoney.Content = "$" + Money.ToString();
            }
            if (pressed.Name == "RdbtnC")
            {
                Money += 45;
                LblMoney.Content = "$" + Money.ToString();
            }
        }

        private void Rdbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Name == "RdbtnA")
            {

            }
            if (pressed.Name == "RdbtnB")
            {
                Money -= 20;
                LblMoney.Content = "$" + Money.ToString();
            }
            if (pressed.Name == "RdbtnC")
            {
                Money -= 45;
                LblMoney.Content = "$" + Money.ToString();
            }

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerRegThanks().Show();
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void BtnCharityInf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Charities.FirstOrDefault(c=>c.CharityId==Convert.ToInt32(CmbCharity.SelectedValue)).CharityDescription);
        }

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
