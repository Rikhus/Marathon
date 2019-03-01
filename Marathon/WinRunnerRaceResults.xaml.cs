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

                    var RunnerInfo = db.Runner.FirstOrDefault(r => r.RunnerId == runnerId);
                    LblGender.Content = RunnerInfo.Gender;

                    int yearOld = DateTime.Now.Year - Convert.ToInt32(RunnerInfo.DateOfBirth.Value.Year);
                    if (DateTime.Now.DayOfYear < RunnerInfo.DateOfBirth.Value.DayOfYear)
                    {
                        yearOld--;
                    }
                    if (yearOld <= 18) LblAge.Content = "до 18";
                    else if (yearOld > 18 && yearOld <= 29) LblAge.Content = "18 - 29";
                    else if (yearOld >= 30 && yearOld <= 39) LblAge.Content = "30 - 39";
                    if (yearOld >= 40 && yearOld <= 55) LblAge.Content = "40 - 55";
                    if (yearOld >= 56 && yearOld <= 70) LblAge.Content = "56 - 70";
                    if (yearOld > 70) LblAge.Content = "больше 70";

                    
                    #region Проверка кол-ва забегов

                    var ResultsLinq = (from reg in db.Registration
                                       join regEv in db.RegistrationEvent on reg.RegistrationId equals regEv.RegistrationId
                                       join ev in db.Event on regEv.EventId equals ev.EventId
                                       join mthn in db.MarathonTbl on ev.MarathonId equals mthn.MarathonId
                                       join evType in db.EventType on ev.EventTypeId equals evType.EventTypeId
                                       join runner in db.Runner on reg.RunnerId equals runner.RunnerId
                                       orderby regEv.RaceTime
                                       where reg.RunnerId == runnerId && !(regEv.RaceTime==null || regEv.RaceTime==0)
                                       select new
                                       {
                                           Marathon = mthn.YearHeld + " " + mthn.Country.CountryName,
                                           Distance = evType.EventTypeName,
                                           Time = regEv.RaceTime,
                                           CummonPlace = "",
                                           CategoryPlace="",
                                           Gender = runner.Gender,
                                           EventId = ev.EventId,
                                           RegisterId=reg.RegistrationId
                                       }).ToList();                    


                    if(ResultsLinq.Count == 0)
                    {
                        MessageBox.Show("Вы еще не соревновались \nУ вас нет результатов");                        
                        return;
                    }

                    #endregion


                    List<Result> ListResult = new List<Result>();

                    var RegistrIds = RunnerInfo.Registration.Where(reg => reg.RunnerId == runnerId).ToList();
                    var RaceTimes = db.RegistrationEvent.OrderBy(rt => rt.RaceTime).Where(u => u.RaceTime != 0 || u.RaceTime != null).ToList();

                    int j = 0;
                    foreach (var item in RegistrIds)
                    {
                        var t = RaceTimes.FindAll(u => u.RegistrationId == item.RegistrationId);
                        
                        foreach (var itemT in t)
                        {
                            var CategoryRaceTimes = RaceTimes.Where(u=>u.EventId== itemT.EventId).ToList();

                            string i = Convert.ToInt32(RaceTimes.IndexOf(itemT) + 1).ToString();
                            string p="";
                            foreach (var asd in CategoryRaceTimes)
                            {
                               p = Convert.ToInt32(CategoryRaceTimes.IndexOf(asd)+1).ToString();
                               
                            }
                            Result res = new Result
                            {
                                Marathon = ResultsLinq[j].Marathon,
                                Distance = ResultsLinq[j].Distance,
                                Time = ResultsLinq[j].Time.ToString(),
                                CummonPlace = i,
                                CategoryPlace = p
                            };
                            ListResult.Add(res);

                        }

                        
                        j++;


                    }
                    ListResults.ItemsSource = ListResult;



                    



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
        
       public class Result
        {
            public string Marathon { get; set; }
            public string Distance { get; set; }
            public string Time { get; set; }
            public string CummonPlace { get; set; }
            public string CategoryPlace { get; set; }
        }
    }
}
