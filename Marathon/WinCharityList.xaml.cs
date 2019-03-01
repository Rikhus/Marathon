using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            LocalStorage.TimeCalc(LblTime);
            LoadAll();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }
       
        public void LoadAll()
        {
            using (var db = new MarathonDBEntities1())
            {
                var charities = db.Charity.ToList();
                List<Data> lizt = new List<Data>();
                string path = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "");
                foreach(var charityOrganization in charities)
                {
                    Data d = new Data
                    {
                        Info = charityOrganization.CharityName + "\n" + "\n"+ charityOrganization.CharityDescription,
                        ImagePath = path +"CharityLogos/" + charityOrganization.CharityLogo
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
