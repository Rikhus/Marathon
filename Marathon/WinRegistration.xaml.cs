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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinRegistration.xaml
    /// </summary>
    public partial class WinRegistration : Window
    {
        public WinRegistration()
        {
            InitializeComponent();loadTime();
        }
        //кнопка назад
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();Close();
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
            if ((TxtPassword.Text == TxtPasswordRepeat.Text) && (TxtPassword.Text!=""))
            {
                if(GetData(@"SELECT * FROM [User] WHERE [Email]='"+TxtEmail.Text+"' OR [Password]='" + TxtPassword + "'") == "")
                {
                    DataBase(@"INSERT INTO [User] ([Email],[Password],[FirstName],[LastName],[Gender]) VALUES ('"+TxtEmail.Text+"','"+TxtPassword+"','"+TxtFirstName.Text+"','"+TxtLastName+"','"+TxtGender+"')");
                }
                else
                {
                    LblInf.Content = "Email и/или пароль заняты";
                }
            }
            else
            {
                LblInf.Content = "Пароли не совпадают";
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
        public int DataBase(string Query)
        {


            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {
                try
                {
                    string temp = String.Format(Query);
                    SqlCommand command = new SqlCommand(temp, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                    return 0;
                }
                catch { return 1;}

            }
        }
    }
}
