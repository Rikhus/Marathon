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
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;

namespace Marathon
{
    public class User
    {
        public static string FirstName;
        public static string LastName;
        public static string Password;
        public static string Email;
        public static string DateOfBirth;
        public static string Gender;
        public static string CountryName;
        public static string CountryCode;
        
        
        
    }
    /// <summary>
    /// Логика взаимодействия для WinRegistration.xaml
    /// </summary>
    public partial class WinRegistration : Window
    {
        public WinRegistration()
        {
            InitializeComponent(); loadTime(); loadCountryData(); loadGenderData();
        }
        //кнопка назад
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show(); Close();
        }
        //кнопка отмены
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            new WinRinnerMenu().Show(); Close();
        }
        //метод отсчета времени
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
        }
        //присвоение атрибутам класса пользователя значеий из полей ввода/выбора
        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            User.Gender = Gender.SelectedItem.ToString();

            if (TxtEmail.Text != "")
            {
                if (CountryList.SelectedItem.ToString() != "")
                {
                    if (DateOfBirth.Text != "")
                    {
                        if (TxtFirstName.Text != "" && TxtLastName.Text != "")
                        {

                            User.Password = PswdBox.Password;
                            User.FirstName = TxtFirstName.Text;
                            User.LastName = TxtFirstName.Text;
                            User.Email = TxtEmail.Text;
                            User.DateOfBirth = DateOfBirth.SelectedDate.ToString();

                            User.CountryName = CountryList.SelectedItem.ToString();
                            //присвоение countrycode из таблицы в соответствии названию страны
                            User.CountryCode = GetData(@"SELECT [CountryCode] FROM [Country] WHERE [CountryName] = '" + User.CountryName + "'");
                        }
                        else
                        {
                            MessageBox.Show("Поле Имя и/или поле Фамилия не заполнены");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана дата рождения");
                        return;
                    }



                }
            }
            else
            {
                MessageBox.Show("Email не может быть пустым");
                return;
            }
            char[] EmailChar = User.Email.ToCharArray();
            //проверка по маске
            int j = 0;
           
            for(int x = 0; x < User.Email.Length; x++)
            {
                if (EmailChar[x] == '@')
                {
                    j = x;
                    try
                    {
                        if (EmailChar[x + 1] != ' ' && EmailChar[x + 2] != ' ' && EmailChar[x + 3] != ' ')
                        {
                            for( int k=j ; k < User.Email.Length ; k++)
                            {
                                if ((k > j + 1) && (k + 1 < User.Email.Length) && (EmailChar[k] == '.'))
                                {
                                    break;
                                }
                                else if (k == User.Email.Length - 1)
                                {
                                    MessageBox.Show("Неверный формат Email");
                                    return;
                                }
                            }
                            break;
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Неверный формат Email");
                        return;
                    }
                }
                else if(x==(User.Email.Length-1))
                {
                    MessageBox.Show("Неверный формат Email");
                    return;
                }
            }
            //проверка заполнения форм ввода
            if (PswdBox.Password == PswdRepeatBox.Password)
            {
                if (PswdBox.Password != "")
                {
                    //проверка выбора пола
                    if (User.Gender != "")
                    {
                        //проверка на зарегистрированность такого email
                        if (GetData(@"SELECT * FROM [User] WHERE [Email]='" + User.Email + "'") == "")
                        {
                            //запполнение таблиц данными
                            if ((!DataBase(@"INSERT INTO [User] ([Email],[Password],[FirstName],[LastName],[RoleId])
                    VALUES ('" + User.Email + "','" + User.Password + "','" + User.FirstName + "','" + User.LastName + "','R')"))
                           && !(DataBase(@"INSERT INTO [Runner] ([Email],[Gender],[DateOfBirth],[CountryCode]) VALUES
                   ('" + User.Email + "','" + User.Gender + "','" + User.DateOfBirth + "','" + User.CountryCode + "')")))
                            {
                                MessageBox.Show("Регистрация прошла успешно!");
                                new WinRunnerAcc().Show(); Close();
                            }
                        }

                        else
                        {
                            MessageBox.Show("Email и/или пароль заняты");
                            return;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Пол не выбран");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не может быть пустым");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
        }
        public string GetData(string Query)
        {


            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {

                string temp = String.Format(Query);
                string results = "";
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results += reader[0];
                    }
                    connection.Close();
                    return results;
                }
                catch { results = "Ошибка"; return results; }

            }
        }
        public bool DataBase(string Query)
        {


            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {
                
               
                    string temp = String.Format(Query);
                    SqlCommand command = new SqlCommand(temp, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                    return false;
                
                

            }
        }

       
        
        public void loadCountryData()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {

                string temp = String.Format(@"SELECT [CountryName] FROM [Country]");
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    
                        string result = reader.GetString(0);
                        CountryList.Items.Add(result);
                        CountryList.Text = result;
                    
                    

                }

                connection.Close();

            }
        }
        public void loadGenderData()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {

                string temp = String.Format(@"SELECT [Gender] FROM [Gender]");
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {


                    string result = reader.GetString(0);
                    Gender.Items.Add(result);
                    Gender.Text = result;



                }

                connection.Close();

            }
        }

        private void BtnFileOpener_Click(object sender, RoutedEventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF";
                openFileDialog.FilterIndex = 1;
                try
                {
                     openFileDialog.ShowDialog();
                     System.IO.StreamReader sr = new
                     System.IO.StreamReader(openFileDialog.FileName);
                     TxtBoxImage.Text = openFileDialog.SafeFileName;
                     sr.Close();
                     var ImageSrc = new BitmapImage(new Uri(openFileDialog.FileName));
                     image.Source = ImageSrc;
                }
                catch
                {
                     TxtBoxImage.Text = "Файл не выбран";
                }

        }
    }
}
