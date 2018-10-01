using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinPrevRes.xaml
    /// </summary>
    public partial class WinPrevRes : Window
    {
        public WinPrevRes()
        {
            InitializeComponent(); loadTime(); FillDataGrid(); ComboBoxDataLoad();
             
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInf().Show();
            Close();
        }
        //метод отсчеча времени до конца марафона
        public void loadTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(2018, 11, 24, 6, 00, 00);
            TimeSpan have = start.Subtract(now);
            if (have.Minutes < 0) { LblTime.Content = "   Марафон закончился"; return; }
            LblTime.Content = have.Days + " дней " + have.Hours + " часов и " + have.Minutes + " минут до начала гонки";

        }
        //заполнение таблицы (тестовый вариант)
        public void FillDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {

                string temp = String.Format(@"SELECT * FROM [Runner]");
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                using (SqlCommand cmdSel = new SqlCommand(temp, connection))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    DataRunner.ItemsSource= dt.DefaultView;
                }
                connection.Close();

            }
        }
        public void ComboBoxDataLoad()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            {
                string result;
                string temp = String.Format(@"SELECT [MarathonName] FROM [Marathon]");
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                    MarathonSel.Items.Add(result);
                    MarathonSel.Text = result;
                }
                reader.Close();
                temp = String.Format(@"SELECT [EventTypeName] FROM [EventType]");
                command = new SqlCommand(temp, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                    DistaceSel.Items.Add(result);
                    DistaceSel.Text = result;

                }
               
                reader.Close();
                temp = String.Format(@"SELECT [Gender] FROM [Gender]");
                command = new SqlCommand(temp, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {


                    result = reader.GetString(0);
                    GenderSel.Items.Add(result);
                    GenderSel.Text = result;



                }
                reader.Close();
                connection.Close();
                AgeSel.SelectedIndex=0;
                AgeSel.Items.Add("<18");
                DistaceSel.Text = "<18";
                AgeSel.Items.Add("18-29");
                DistaceSel.Text = "18-29";
                AgeSel.Items.Add("30-39");
                DistaceSel.Text = "30-39";
                AgeSel.Items.Add("40-55");
                DistaceSel.Text = "40-55";
                AgeSel.Items.Add("56-70");
                DistaceSel.Text = "56-70";
                AgeSel.Items.Add(">70");
                DistaceSel.Text = ">70";
            }
        }
    }
}
