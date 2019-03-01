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
    /// Логика взаимодействия для WinRunnerSponsorship.xaml
    /// </summary>
    public partial class WinRunnerSponsorship : Window
    {
        public WinRunnerSponsorship()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            Load();
        }
        decimal Amount=0;

        public void Load()
        {
            try
            {
                using (var db = new MarathonDBEntities1())
                {
                    int LastMarathon = db.MarathonTbl.Count();
                    int runnerId = Convert.ToInt32(LocalStorage.UserClass.RunnerId);
                    var SponsorSh = (from runner in db.Runner
                                     join reg in db.Registration on runner.RunnerId equals reg.RunnerId
                                     join regEv in db.RegistrationEvent on reg.RegistrationId equals regEv.RegistrationId
                                     join ev in db.Event on regEv.EventId equals ev.EventId
                                     join sp in db.Sponsorship on reg.RegistrationId equals sp.RegistrationId
                                     
                                     where runner.RunnerId == runnerId  && ev.MarathonId==LastMarathon
                                     select new
                                     {
                                         regId=reg.RegistrationId,
                                         spName= sp.SponsorName,
                                         amount = sp.Amount
                                        
                                     }
                        ).ToList();
                    if (SponsorSh.Count == 0)
                    {
                        MessageBox.Show("У вас нет спонсоров на текущий марафон");
                        return;
                    }
                    var SponsLst = SponsorSh.Distinct();
                    SponsorsList.ItemsSource = SponsLst;

                    string path = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "");                    
                    int id = SponsorSh[0].regId;
                    var charityInf = db.Registration.FirstOrDefault(reg=>reg.RegistrationId==id).Charity;
                    LblChName.Content = charityInf.CharityName;
                    LblDesc.Text = charityInf.CharityDescription;
                    ImgLogo.Source = new BitmapImage(new Uri(path+"CharityLogos/"+charityInf.CharityLogo));
                    foreach (var item in SponsLst)
                    {
                        Amount += item.amount;
                    }
                    LblCount.Content = "$" + Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }
     
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
