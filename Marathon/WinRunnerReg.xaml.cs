﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
    /// Логика взаимодействия для WinRunnerReg.xaml
    /// </summary>
    public partial class WinRunnerReg : Window
    {
        public WinRunnerReg()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadAll();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        
        public void LoadAll()
        {
            using (var db = new MarathonDBEntities1())
            {
                var CountryList = db.Country.ToList();
                CmbCountry.ItemsSource = CountryList;
                CmbCountry.DisplayMemberPath = "CountryName";
                CmbCountry.SelectedValuePath = "CountryCode";
                CmbCountry.SelectedIndex = 0;

                var GenderList = db.Gender.ToList();
                CmbGender.ItemsSource = GenderList;
                CmbGender.DisplayMemberPath = "Gender1";
                CmbGender.SelectedValuePath = "Gender1";
                CmbGender.SelectedIndex = 0;
            }
        } 

        public class RunnerReg
        {
            public static string Country { get; set; }
            public static string Gender { get; set; }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {        
            User NewUser = new User();
            Runner NewRunner = new Runner();  

            if (PasswdBox.Password == "" || PasswdBox.Password == " "|| ConfirmPasswdBox.Password == "" || ConfirmPasswdBox.Password == " " 
                || TxtFirstName.Text == "" || TxtFirstName.Text== " " || TxtLastName.Text == "" || TxtLastName.Text == " " || BirthOfDatePick.SelectedDate==null)
            {
                MessageBox.Show("Заполнены не все поля!");
                return;
            }

            NewUser.RoleId = "R";
            NewUser.FirstName = TxtFirstName.Text;
            NewUser.LastName = TxtLastName.Text;
            NewRunner.Gender = CmbGender.SelectedValue.ToString();
            NewRunner.CountryCode = CmbCountry.SelectedValue.ToString();

            #region Проверка Email.
            EmailAddressAttribute emailCheck = new EmailAddressAttribute();
            if (!emailCheck.IsValid(TxtEmail.Text))
            {
                MessageBox.Show("Введен некорректный Email");
                return;
            }

            #endregion
            NewUser.Email = TxtEmail.Text;
            NewRunner.Email = TxtEmail.Text;

            #region Проверка пароля.
            if (PasswdBox.Password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов");
                return;
            }

            if (ConfirmPasswdBox.Password != PasswdBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

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
            #endregion
            NewUser.Password = PasswdBox.Password;

            #region Подсчет возраста.
            int yearOld = DateTime.Now.Year-Convert.ToInt32(BirthOfDatePick.SelectedDate.Value.Year);
            if (DateTime.Now.DayOfYear<BirthOfDatePick.SelectedDate.Value.DayOfYear)
            {
                yearOld--;
                if (yearOld < 10)
                {
                    MessageBox.Show("Вы не можете зарегистрироваться, так как вам меньше 10 лет");
                    return;
                }
            }
            #endregion
            NewRunner.DateOfBirth = Convert.ToDateTime(BirthOfDatePick.SelectedDate);

            #region Сохранение изображения.
            if(LblFileName.Content != "")
            {
                try
                {
                    Byte[] ImgData = null;
                    FileStream stream = new FileStream(LblFileName.Content.ToString(), FileMode.Open, FileAccess.Read);
                    StreamReader read = new StreamReader(stream);
                    ImgData = new byte[stream.Length - 1];
                    stream.Read(ImgData, 0, (int)stream.Length - 1);

                    NewUser.Image = ImgData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion

            using (var DataBase = new MarathonDBEntities1())
            {
                DataBase.User.Add(NewUser);
                DataBase.Runner.Add(NewRunner);
                DataBase.SaveChanges();
            }

            #region Сохранение данных в LocalStorage.
            LocalStorage.UserClass.Email = TxtEmail.Text;
            LocalStorage.UserClass.FirstName = TxtFirstName.Text;
            LocalStorage.UserClass.LastName = TxtLastName.Text;
            LocalStorage.UserClass.RunnerId = NewRunner.RunnerId.ToString();
            #endregion
            new WinRegForTheMarathon().Show();
            Close();

        }

        private void BtnFileFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                OpenFile.Filter = "Изображения (*.png, *.jpg) | *.png; *.jpg";
                if (OpenFile.ShowDialog()==true)
                {
                    ImgProfile.Source = new BitmapImage(new Uri(OpenFile.FileName));
                    LblFileName.Content = OpenFile.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
