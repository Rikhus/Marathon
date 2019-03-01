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
    /// Логика взаимодействия для WinVolunteers.xaml
    /// </summary>
    public partial class WinVolunteers : Window
    {
        public WinVolunteers()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            Load();

            #region Добавил пункты сортировки
            List<SortByClass> sorts = new List<SortByClass>();
            sorts.Add(new SortByClass { Id = "1", Value = "Фамилия" });
            sorts.Add(new SortByClass { Id = "2", Value = "Имя" });
            sorts.Add(new SortByClass { Id = "3", Value = "Страна" });
            sorts.Add(new SortByClass { Id = "4", Value = "Пол" });
            CmbSortBy.ItemsSource = sorts;
            CmbSortBy.DisplayMemberPath = "Value";
            CmbSortBy.SelectedValuePath = "Id";
            CmbSortBy.SelectedIndex = 0;
            #endregion

        }

        private void Load()
        {

            #region Код загрузки и сортировки данных
            try
            {                
                using (var db = new MarathonDBEntities1())
                {
                    var Volunteers = (from vol in db.Volunteer
                                      select new
                                      {
                                          LastName = vol.LastName,
                                          FirstName = vol.FirstName,
                                          gender = vol.Gender,
                                          country = vol.Country.CountryName
                                      }
                        ).ToList();
                    switch (CmbSortBy.SelectedValue)
                    {
                        case "1":
                            VolunteersList.ItemsSource = Volunteers.OrderBy(v => v.LastName);
                            break;
                        case "2":
                            VolunteersList.ItemsSource = Volunteers.OrderBy(v => v.FirstName);
                            break;
                        case "3":
                            VolunteersList.ItemsSource = Volunteers.OrderBy(v => v.country);
                            break;
                        case "4":
                            VolunteersList.ItemsSource = Volunteers.OrderBy(v => v.gender);
                            break;
                    }
                    LblCount.Content = Volunteers.Count();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        #region Управление окном(назад, выход)

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinAdminMenu().Show();
            Close();
        }

        #endregion

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void BtnDownloadVolunteer_Click(object sender, RoutedEventArgs e)
        {
            new WinLoadVolunteers().Show();
            Close();
        }

       

      
        class SortByClass
        {
            public string Value { get; set; }
            public string Id { get; set; }
        }
    }
}
