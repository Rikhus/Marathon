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
    /// Логика взаимодействия для WinCharitiesManage.xaml
    /// </summary>
    public partial class WinCharitiesManage : Window
    {
        List<Data> lizt = new List<Data>();

        public WinCharitiesManage()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadAll();
            LocalStorage.CharityClass.CharityName ="";
            LocalStorage.CharityClass.CharityDesc = "";
            LocalStorage.CharityClass.CharityLogo = "";
            LocalStorage.CharityClass.CharityId = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinAdminMenu().Show();
            Close();
        }

        public void LoadAll()
        {
            using (var db = new MarathonDBEntities1())
            {
                var charities = db.Charity.ToList();
                string path = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe","");
                foreach (var charityOrganization in charities)
                {
                    Data d = new Data
                    {
                        Info = charityOrganization.CharityDescription,
                        Name = charityOrganization.CharityName,
                        ImagePath = path + "CharityLogos/" + charityOrganization.CharityLogo,
                        CharityId = charityOrganization.CharityId.ToString()
                    };
                    lizt.Add(d);
                    
                    
                }
                ListCharity.ItemsSource = lizt;

            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "");
                LocalStorage.CharityClass.CharityName = lizt[ListCharity.SelectedIndex].Name;
                LocalStorage.CharityClass.CharityDesc = lizt[ListCharity.SelectedIndex].Info;
                LocalStorage.CharityClass.CharityLogo = lizt[ListCharity.SelectedIndex].ImagePath.Replace(path,"");
                LocalStorage.CharityClass.CharityId = lizt[ListCharity.SelectedIndex].CharityId;
            }
            catch
            {
                MessageBox.Show("Выберите мышкой какую организацию редактировать");
                return;
            }
                new WinEditAddCharity().Show();
                Close();
            
        }

        public class Data
        {
            public String Info { get; set; }
            public String Name { get; set; }
            public String BtnName { get; set; }
            public String ImagePath { get; set; }
            public string CharityId { get; set; }

        }

        private void BtnAddOrEdit_Click(object sender, RoutedEventArgs e)
        {
            new WinEditAddCharity().Show();
            Close();
        }
    }
}
