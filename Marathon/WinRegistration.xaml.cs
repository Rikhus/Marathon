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
            InitializeComponent(); loadTime(); loadCountryData();
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

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            string selectedGender = Gender.SelectedItem.ToString();
            if (selectedGender != "") User.Gender = selectedGender;
            if ((PswdBox.Password == PswdRepeatBox.Password) && (User.Gender != "") && (DateOfBirth.Text != "")&&(CountryList.SelectedItem.ToString()!=""))
            {
                
                User.Password = PswdBox.Password;
                User.FirstName = TxtFirstName.Text;
                User.LastName = TxtFirstName.Text;
                User.Email = TxtEmail.Text;
                User.DateOfBirth = DateOfBirth.Text;
                User.CountryName = CountryList.SelectedItem.ToString();
                User.CountryCode=GetData(@"SELECT [CountryCode] FROM [Country] WHERE [CountryName] = '"+User.CountryName+"'");



            }

            if ((PswdBox.Password == PswdRepeatBox.Password) && (PswdBox.Password != ""))
            {
                if (GetData(@"SELECT * FROM [User] WHERE [Email]='" + User.Email + "' AND [Password]='" + User.Password + "'") == "")
                {
                    if ((!DataBase(@"INSERT INTO [User] ([Email],[Password],[FirstName],[LastName],[RoleId])
                    VALUES ('" + User.Email + "','" + User.Password + "','" + User.FirstName + "','" + User.LastName + "','R')"))
                    && !(DataBase(@"INSERT INTO [Runner] ([Email],[Gender],[DateOfBirth],[CountryCode]) VALUES
                    ('" + User.Email + "','" + User.Gender + "','" + User.DateOfBirth + "','" + User.CountryCode + "')")))
                    {
                        new WinRunnerAcc().Show(); Close();
                    }
                }
                else
                {
                    MessageBox.Show("Email и/или пароль заняты");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
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
    }
}
