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
    /// Логика взаимодействия для WinRunnersInfoManage.xaml
    /// </summary>
    
    public partial class WinRunnersInfoManage : Window
    {
        
        public WinRunnersInfoManage()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);

            EmailGrid.Visibility = Visibility.Collapsed;
            #region подготовка для сортировки 

            List<SortBy> sorts = new List<SortBy>();
            sorts.Add(new SortBy { Id = "1", Value = "Фамилия" });
            sorts.Add(new SortBy { Id = "2", Value = "Имя" });
            sorts.Add(new SortBy { Id = "3", Value = "Email" });
            CmbSortBy.ItemsSource = sorts;
            CmbSortBy.DisplayMemberPath = "Value";
            CmbSortBy.SelectedValuePath = "Id";
            CmbSortBy.SelectedIndex = 0;

            using (var db = new MarathonDBEntities1())
            {
                var Status = db.RegistrationStatus.ToList();
                CmbStatus.ItemsSource = Status;
                CmbStatus.DisplayMemberPath = "RegistrationStatus1";
                CmbStatus.SelectedValuePath = "RegistrationStatusId";


                var Distance = db.EventType.ToList();
                CmbDistance.ItemsSource = Distance;
                CmbDistance.DisplayMemberPath = "EventTypeName";
                CmbDistance.SelectedValuePath = "EventTypeId";

            }

            #endregion
            CmbStatus.SelectedIndex = 0;
            CmbDistance.SelectedIndex = 0;
            Load();
        }

        public void Load()
        {
            try
            {
                using (var db = new MarathonDBEntities1())
                {
                    
                    int selectedStatus = Convert.ToInt32(CmbStatus.SelectedValue.ToString());
                    var Runners = (from runner in db.Runner
                                   join user in db.User on runner.Email equals user.Email
                                   join reg in db.Registration on runner.RunnerId equals reg.RunnerId
                                   join regEv in db.RegistrationEvent on reg.RegistrationId equals regEv.RegistrationId
                                   join Ev in db.Event on regEv.EventId equals Ev.EventId
                                   join regStat in db.RegistrationStatus on reg.RegistrationStatusId equals regStat.RegistrationStatusId
                                   where regStat.RegistrationStatusId == selectedStatus && Ev.EventTypeId==CmbDistance.SelectedValue.ToString()
                                   select new
                                   {
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       Email = runner.Email,
                                       Status = regStat.RegistrationStatus1,
                                       StatusId = regStat.RegistrationStatusId
                                   }
                        ).ToList();

                    #region сортировка                   

                    switch (CmbSortBy.SelectedValue)
                    {
                        case "1":
                            RunnersList.ItemsSource = Runners.OrderBy(s => s.LastName);
                            break;
                        case "2":
                            RunnersList.ItemsSource = Runners.OrderBy(s => s.FirstName);
                            break;
                        case "3":
                            RunnersList.ItemsSource = Runners.OrderBy(s => s.Email);
                            break;
                    }
                    #endregion

                    LblCount.Content = Runners.Count();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Управление окном 
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinCoordinatorMenu().Show();
            Close();
        }
        #endregion

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void BtnInfoDownload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmailsShow_Click(object sender, RoutedEventArgs e)
        {
            EmailGrid.Visibility = Visibility.Visible;

            foreach(var runner in RunnersList.Items)
            {
                var i = runner.ToString().Split(',','=');
                string info = ""+i[1] + " " + i[3] + " "+i[5]+"\n";
                TxtEmailInGrid.Text += info;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        class SortBy
        {
            public string Value { get; set; }
            public string Id { get; set; }
        }

        private void BtnGridExit_Click(object sender, RoutedEventArgs e)
        {
            EmailGrid.Visibility = Visibility.Collapsed;
        }
    }
}
