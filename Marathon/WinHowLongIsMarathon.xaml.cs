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
    /// Логика взаимодействия для WinHowLongIsMarathon.xaml
    /// </summary>
    public partial class WinHowLongIsMarathon : Window
    {
        public WinHowLongIsMarathon()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadData();
        }

        List<SpeedClass> speedList = new List<SpeedClass>();
        List<DistanceClass> distanceList = new List<DistanceClass>();

        private void LoadData()
        {
            try
            {
                using (var db = new MarathonDBEntities1())
                {
                    var speed = db.Speed.AsNoTracking().ToList();
                    foreach (var sp in speed)
                    {
                        string way = Assembly.GetExecutingAssembly().Location.Replace("Marathon.exe", "how long is marathon/");
                        SpeedClass newSpeed = new SpeedClass
                        {
                            Id = sp.SpeedId,
                            Name = sp.Name,
                            ImgSource= new BitmapImage(new Uri( way+sp.Image)),
                            Speed = sp.TopSpeed
                        };
                        speedList.Add(newSpeed);
                    }
                    ListVSpeed.ItemsSource = speedList;
                    ListVSpeed.SelectedValuePath = "Id";

                    
                    var distances = db.Distance.AsNoTracking().ToList();
                    foreach (var sp in distances)
                    {
                        string way = Assembly.GetExecutingAssembly().Location.Replace("Marathon.exe", "how long is marathon/");
                        DistanceClass newDist = new DistanceClass
                        {
                            Id = sp.DistanceId,
                            Name = sp.Name,
                            ImgSource = new BitmapImage(new Uri(way + sp.Image)),
                            Distance = sp.Length
                        };
                        distanceList.Add(newDist);
                    }
                    ListVDistance.ItemsSource = distanceList;
                    ListVDistance.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinMoreInfo().Show();
            Close();
        }
        public class SpeedClass
        {
            public int Id { get; set; }
            public BitmapImage ImgSource { get; set; }
            public string Name { get; set; }
            public decimal Speed { get; set; }
        }

        public class DistanceClass
        {
            public int Id { get; set; }
            public BitmapImage ImgSource { get; set; }
            public string Name { get; set; }
            public decimal Distance { get; set; }
        }

        private void ListVSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedImage.Source = speedList[ListVSpeed.SelectedIndex].ImgSource;
                SelectedName.Content = speedList[ListVSpeed.SelectedIndex].Name;
                decimal res = 42 / speedList[ListVSpeed.SelectedIndex].Speed;
                string resString = Math.Round(res, 2).ToString();

                LblResult.Text = "Максимальная скорость " + SelectedName.Content + " " + speedList[ListVSpeed.SelectedIndex].Speed +
                                     ". Это займет " + resString + "km/h чтобы завершить 42km марафон";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListVDistance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedImage.Source = distanceList[ListVDistance.SelectedIndex].ImgSource;
                SelectedName.Content = distanceList[ListVDistance.SelectedIndex].Name;

                decimal res = 42000 / distanceList[ListVDistance.SelectedIndex].Distance;
                string resString = Math.Round(res, 2).ToString();
                LblResult.Text = "Длина " + SelectedName.Content + " " + distanceList[ListVDistance.SelectedIndex].Distance +
                                     ". Это займет " + resString + " из них, чтобы покрыть расстояние 42km марафон";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
