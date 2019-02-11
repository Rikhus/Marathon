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

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinCharityList.xaml
    /// </summary>
    public partial class WinCharityList : Window
    {
        public WinCharityList()
        {
            InitializeComponent();
            TimeCalc();
            LoadAll();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }
        public void TimeCalc()
        {
            DateTime startTime = new DateTime(2019, 9, 21);
            DateTime now = DateTime.Now;
            TimeSpan span = startTime.Subtract(now);
            LblTime.Content = "Осталось " + span.Days + " дней " + span.Hours + " часов " + span.Minutes + " минут.";
        }
        public void LoadAll()
        {
            using (var db = new MarathonDBEntities1())
            {
                var charities = db.Charity.ToList();
                List<Data> lizt = new List<Data>();
                foreach(var charityOrganization in charities)
                {
                    Data d = new Data
                    {
                        Info = charityOrganization.CharityName + "\n" + "\n"+ charityOrganization.CharityDescription,
                        ImagePath = "CharityLogos/" + charityOrganization.CharityLogo
                    };
                    lizt.Add(d);
                }
                ListCharity.ItemsSource = lizt;

            }
        }
        public class Data
        {
            public String Info { get; set; }
            public String ImagePath { get; set; }
            
        }

       
    }
   
}
