using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Логика взаимодействия для WinFullLogin.xaml
    /// </summary>
    public partial class WinFullLogin : Window
    {
        public WinFullLogin()
        {
            InitializeComponent();
            loadTime();
            GetData();
        }

        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";
        }
        //кнопка возврата на главную страницу
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        //переход в окно авторизации
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // new WinLogin().Show();
            var window = new WinLogin();
            window.Owner = this;
            window.Show();
        }
        //кнопка возврата на главный экран
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        public void GetData()
        {
            
                
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {
                
                string temp = String.Format(@"SELECT * FROM [User]");
                string results = "";
                SqlCommand command = new SqlCommand(temp,connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    results += reader[1];
                }
                
                
                LblTest.Content = temp;
                connection.Close();
                
            }
        }

    }
}
