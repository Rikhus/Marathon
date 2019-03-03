using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для WinBMI.xaml
    /// </summary>
    public partial class WinBMI : Window
    {
        public WinBMI()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if(TxtHeight.Text=="" || TxtMass.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            decimal state = Convert.ToDecimal(TxtMass.Text) / ((Convert.ToDecimal(TxtHeight.Text) / 100) * (Convert.ToDecimal(TxtHeight.Text) / 100));
            LblState.Content = "Ваш BMI равен " + Math.Round(state, 1).ToString();
            string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "");
            if (state < (decimal)18.5)
            {
                ImgState.Source = new BitmapImage(new Uri(way+"BMI Icons\\bmi-underweight-icon.png"));
            }
            if (state >= (decimal)18.5 && state <(decimal)25)
            {
                ImgState.Source = new BitmapImage(new Uri(way + "BMI Icons\\bmi-healthy-icon.png"));
            }
            if (state >= (decimal)25 && state <= (decimal)30)
            {
                ImgState.Source = new BitmapImage(new Uri(way + "BMI Icons\\bmi-overweight-icon.png"));
            }
            if (state > (decimal)30)
            {
                ImgState.Source = new BitmapImage(new Uri(way + "BMI Icons\\bmi-obese-icon.png"));
            }
        }

        private void Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void BtnGend_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Name == "BtnMale")
            {
                BordFemale.Background = Brushes.Azure;
                BordMale.Background = Brushes.LightGray;
            }
            if ((sender as Button).Name == "BtnFemale")
            {
                BordMale.Background = Brushes.Azure;
                BordFemale.Background = Brushes.LightGray;
            }
        }
    }
}
