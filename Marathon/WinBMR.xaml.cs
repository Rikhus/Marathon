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
    /// Логика взаимодействия для WinBMR.xaml
    /// </summary>
    public partial class WinBMR : Window
    {
        int selectedGender = 0;
        decimal BMR = 0;
        public WinBMR()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }
        private void Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {

            if (TxtAge.Text == "")
            {
                MessageBox.Show("Не заполнен возраст");
                return;
            }
            if (TxtMass.Text == "")
            {
                MessageBox.Show("Не заполнен вес");
                return;
            }
            if (TxtHeight.Text == "")
            {
                MessageBox.Show("Не заполнен рoст");
                return;
            }
            if (selectedGender == 0)
            {
                MessageBox.Show("Не выбран пол");
                return;
            }
            if (selectedGender == 1)
            {
                 BMR = 66 + ((decimal)13.7 * Convert.ToDecimal(TxtMass.Text)) + ((decimal)5 * Convert.ToDecimal(TxtHeight.Text)) - (decimal)(6.8 * Convert.ToInt32(TxtAge.Text));
            }
            if (selectedGender == 2)
            {
                BMR = 655 + ((decimal)9.6 * Convert.ToDecimal(TxtMass.Text)) + ((decimal)1.8 * Convert.ToDecimal(TxtHeight.Text)) - (decimal)(4.7 * Convert.ToInt32(TxtAge.Text));
            }
            LblBMR.Content =BMR.ToString();
        }

        private void BtnGend_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "BtnMale")
            {
                selectedGender = 1;
                BordFemale.Background = Brushes.Azure;
                BordMale.Background = Brushes.LightGray;
            }
            if ((sender as Button).Name == "BtnFemale")
            {
                selectedGender = 2;
                BordMale.Background = Brushes.Azure;
                BordFemale.Background = Brushes.LightGray;
            }
        }

        private void BtnInf_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
