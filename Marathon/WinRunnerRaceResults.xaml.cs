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
    /// Логика взаимодействия для WinRunnerRaceResults.xaml
    /// </summary>
    public partial class WinRunnerRaceResults : Window
    {
        public WinRunnerRaceResults()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadResults();
        }

        private void BtnAllResults_Click(object sender, RoutedEventArgs e)
        {

        }

        public  void LoadResults()
        {
            try
            {
                using (var db = new MarathonDBEntities1())
                {
                    
                    int runnerId = Convert.ToInt32(LocalStorage.UserClass.RunnerId);

                    var ResultsLinq = (from reg in db.Registration
                                       join regEv in db.RegistrationEvent on reg.RegistrationId equals regEv.RegistrationId
                                       join ev in db.Event on regEv.EventId equals ev.EventId
                                       join mthn in db.MarathonTbl on ev.MarathonId equals mthn.MarathonId
                                       join evType in db.EventType on ev.EventTypeId equals evType.EventTypeId
                                       join runner in db.Runner on reg.RunnerId equals runner.RunnerId
                                       
                                       orderby regEv.RaceTime
                                       where reg.RunnerId == runnerId
                                       select new
                                       {
                                           Marathon = mthn.MarathonName,
                                           Distance = evType.EventTypeName,
                                           Time = regEv.RaceTime,
                                           CummonPlace = "",
                                           CategoryPlace="",                                           
                                       }).ToList();                    

                    ListResults.ItemsSource = ResultsLinq;
                    var RunnerInfo = db.Runner.FirstOrDefault(r=> r.RunnerId == runnerId);
                    LblGender.Content = RunnerInfo.Gender;
                    int yearOld = DateTime.Now.Year - Convert.ToInt32(RunnerInfo.DateOfBirth.Value.Year);
                    if (DateTime.Now.DayOfYear < RunnerInfo.DateOfBirth.Value.DayOfYear)
                    {
                        yearOld--;
                    }
                    LblAge.Content = yearOld.ToString();
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
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
        /*
       public class ListResult
        {
            public static string Marathon { get; set; }
            public static string Distance { get; set; }
            public static int Time { get; set; }
            public static string CummonPlace { get; set; }
            public static string CategoryPlace { get; set; }
        }*/
    }
}
