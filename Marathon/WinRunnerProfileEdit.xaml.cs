using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для WinRunnerProfileEdit.xaml
    /// </summary>
    public partial class WinRunnerProfileEdit : Window
    {
        public WinRunnerProfileEdit()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadAll();
        }
        public void LoadAll()
        {
            using (var db = new MarathonDBEntities1())
            {
                LblEmail.Content = LocalStorage.UserClass.Email;
                var CountryList = db.Country.OrderBy(c=>c.CountryName).ToList();
                CmbCountry.ItemsSource = CountryList;
                CmbCountry.DisplayMemberPath = "CountryName";
                CmbCountry.SelectedValuePath = "CountryCode";
                CmbCountry.SelectedIndex = 0;

                var Gender = db.Gender.ToList();
                CmbGender.ItemsSource = Gender;
                CmbGender.DisplayMemberPath = "Gender1";
                CmbGender.SelectedValuePath = "Gender1";
                CmbGender.SelectedIndex = 0;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if(TxtFirstName.Text=="" || TxtLastName.Text=="" || DayOfBirthPick.SelectedDate == null||PasswdBox.Password=="" || ConfirmPasswdBox.Password=="")
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            
            // Проверка пароля с Regex.
            Regex reg = new Regex(@"[a-z]");

            if (!reg.IsMatch(PasswdBox.Password))
            {
                MessageBox.Show("Пароль должен содержать как минимум 1 прописную букву");
                return;
            }

            reg = new Regex(@"[0-9]");
            if (!reg.IsMatch(PasswdBox.Password))
            {
                MessageBox.Show("Пароль должен содержать как минимум 1 цифру");
                return;
            }

            reg = new Regex(@"[!@#$%^]");
            if (!reg.IsMatch(PasswdBox.Password))
            {
                MessageBox.Show("Пароль должен содержать как минимум один из следующих символов\n !@#$%^");
                return;
            }
            if (PasswdBox.Password != ConfirmPasswdBox.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            
        }

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^a-z | а-я]");
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
