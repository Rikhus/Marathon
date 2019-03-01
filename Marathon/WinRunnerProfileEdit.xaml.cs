using Microsoft.Win32;
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
            #region Загрузка из базы и вывод инфы о пользователе
            using (var db = new MarathonDBEntities1())
            {
                LblEmail.Content = LocalStorage.UserClass.Email;
                TxtFirstName.Text = LocalStorage.UserClass.FirstName;
                TxtLastName.Text = LocalStorage.UserClass.LastName;
                
                var CountryList = db.Country.AsNoTracking().OrderBy(c=>c.CountryName).ToList();
                CmbCountry.ItemsSource = CountryList;
                CmbCountry.DisplayMemberPath = "CountryName";
                CmbCountry.SelectedValuePath = "CountryCode";

                var Gender = db.Gender.AsNoTracking().ToList();
                CmbGender.ItemsSource = Gender;
                CmbGender.DisplayMemberPath = "Gender1";
                CmbGender.SelectedValuePath = "Gender1";
                //вывод инфы
                var runnerInf= db.Runner.AsNoTracking().FirstOrDefault(r => r.Email == LocalStorage.UserClass.Email);
                CmbGender.SelectedValue = runnerInf.Gender;
                DateOfBirthPick.SelectedDate = runnerInf.DateOfBirth;
                CmbCountry.SelectedValue = runnerInf.CountryCode;

                var user = db.User.AsNoTracking().FirstOrDefault(u=>u.Email==LocalStorage.UserClass.Email);

                // Загрузка изображения из бд.
                try
                {
                    var i = new BitmapImage();
                    using (var ms = new MemoryStream(user.Image))
                    {
                        ms.Position = 0;
                        i.BeginInit();
                        i.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        i.CacheOption = BitmapCacheOption.OnLoad;
                        i.UriSource = null;
                        i.StreamSource = ms;
                        i.EndInit();
                    }
                    i.Freeze();

                    ImgProfile.Source = i;
                }
                catch
                {

                }
            }
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (TxtFirstName.Text=="" || TxtLastName.Text=="" || DateOfBirthPick.SelectedDate == null)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }

            #region Проверка пароля.
            if (PasswdBox.Password != "" && PasswdBox.Password != " ")
            {
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
            #endregion

            #region Проверка возраста
            int yearOld = DateTime.Now.Year - Convert.ToInt32(DateOfBirthPick.SelectedDate.Value.Year);
            if (DateTime.Now.DayOfYear < DateOfBirthPick.SelectedDate.Value.DayOfYear)
            {
                yearOld--;
                if (yearOld < 10)
                {
                    MessageBox.Show("Вам должно быть больше 10 лет");
                    return;
                }
            }
            #endregion


            try
            {
                using (var db = new MarathonDBEntities1())
                {
                //обновление бегуна
                var updRunner = db.Runner.FirstOrDefault(r=>r.Email==LocalStorage.UserClass.Email);
                updRunner.CountryCode = CmbCountry.SelectedValue.ToString();
                updRunner.DateOfBirth = DateOfBirthPick.SelectedDate;
                updRunner.Gender = CmbGender.SelectedValue.ToString();

                //обновление юзера
                var updUser = db.User.FirstOrDefault(u => u.Email == LocalStorage.UserClass.Email);
                if (PasswdBox.Password !="" && PasswdBox.Password!=" ")
                {
                    updUser.Password = PasswdBox.Password;
                }
                updUser.FirstName = TxtFirstName.Text;
                updUser.LastName = TxtLastName.Text;

                if (TxtPhotoFile.Text != "")
                {
                        Byte[] img = null;
                        FileStream stream = new FileStream(TxtPhotoFile.Text, FileMode.Open, FileAccess.Read);
                        StreamReader read = new StreamReader(stream);
                        img = new byte[stream.Length - 1];
                        stream.Read(img,0,(int)stream.Length-1);
                        updUser.Image = img;
                }

                db.SaveChanges();
                MessageBox.Show("Изменения внесены успешно");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^a-z | а-я]",RegexOptions.IgnoreCase);
            e.Handled = reg.IsMatch(e.Text);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnFindPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Изображение (*.png; *.jpg)|*.png; *.jpg";
            if (openFile.ShowDialog()==true)
            {
                TxtPhotoFile.Text = openFile.FileName;
                ImgProfile.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
