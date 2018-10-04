using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для WinCharityInf.xaml
    /// </summary>
 
    public partial class WinCharityInf : Window
    {
        
        public WinCharityInf()
        {
            InitializeComponent();
            loadTime();
            loadAllData();
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInf().Show(); Close();
        }
        public void loadAllData()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.3.168;Initial Catalog=Marathon;User ID=admin;Password=Qwerty1234"))
            { 
                

                string temp = String.Format(@"SELECT COUNT(*) FROM [Charity]");
                SqlCommand command = new SqlCommand(temp, connection);
                connection.Open();
                int count=0;
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //string countInStr = reader.GetString(0);
                    //count = Int32.Parse(countInStr);
                    count = reader.GetInt32(0);
                }
                reader.Close();
                string[] result = new string[count];
                for (int j=0; j <= count; j++)
                {
                    temp = String.Format(@"SELECT [CharityLogo] FROM [Charity] WHERE [CharityId] = '"+j+"'");
                    command = new SqlCommand(temp, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            result[j] = reader.GetString(0);
                        }
                        catch (Exception e) { }
                    }
                    reader.Close();
                    


                }
                temp = String.Format(@"SELECT [CharityName],[CharityDescription] FROM [Charity]");
                DataTable dt = new DataTable();
                command = new SqlCommand(temp, connection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt.Columns.Add("Image");
                
                
                da.Fill(dt);
                                
                
                CharityData.ItemsSource = dt.DefaultView;

                connection.Close();
                

            }
        }
    }
}
