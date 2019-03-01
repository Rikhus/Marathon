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
    /// Логика взаимодействия для WinInteractiveMap.xaml
    /// </summary>
    public partial class WinInteractiveMap : Window
    {
        
        public WinInteractiveMap()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadInfo();
        }

        List<Checkpoint> checkpoints = new List<Checkpoint>();
        string lastMarathon = "";

        void LoadInfo()
        {
            using (var db = new MarathonDBEntities1())
            {
                checkpoints = db.Checkpoint.ToList();
                int count = db.MarathonTbl.Count();
                lastMarathon = db.MarathonTbl.FirstOrDefault(m => m.MarathonId == count).CityName;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Feature> fList = new List<Feature>();
            Feature d = new Feature();
            switch ((sender as Button).Name)
            {
                #region Вывод информации в зависимости от нажатой кнопки
                case "Btn1":
                    
                    if (checkpoints[0].Drinks == 1)
                    {
                        string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "MapIcons\\map-icon-drinks.png");
                        Feature f = new Feature
                        {
                            feature = "-Стенд для питья",
                            img = new BitmapImage(new Uri(way))
                        };
                        fList.Add(f);
                    }
                    if (checkpoints[0].EnergyBars == 1)
                    {
                        string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "MapIcons\\map-icon-energy-bars.png");
                        Feature f = new Feature
                        {
                            feature = "- Энергитические батончики\n",
                            img = new BitmapImage(new Uri(way))
                        };
                        fList.Add(f);
                    }
                    if (checkpoints[0].Information == 1)
                    {
                       
                        d.feature = "- Информационный стенд\n";
                        string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "MapIcons\\map-icon-information.png");
                        d.img = new BitmapImage(new Uri(way));
                        fList.Add(d);
                    }
                    if (checkpoints[0].Toilets == 1)
                    {
                      
                        d.feature = "- Туалеты\n";
                        string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "MapIcons\\map-icon-toilets.png");
                        d.img = new BitmapImage(new Uri(way));
                        fList.Add(d);
                    }
                    if (checkpoints[0].Medical == 1)
                    {

                        d.feature = "- Медицинский пункт\n";
                        string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "MapIcons\\map-icon-medical.png");
                        d.img = new BitmapImage(new Uri(way));
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[0].CheckpointId;
                    LblLandmark.Content = checkpoints[0].Landmark;
                    FeaturesList.ItemsSource = fList;

                    break;
                case "Btn2":
                    if (checkpoints[1].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[1].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[1].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[1].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[1].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[1].CheckpointId;
                    LblLandmark.Content = checkpoints[1].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn3":
                    if (checkpoints[2].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[2].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[2].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[2].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[2].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[2].CheckpointId;
                    LblLandmark.Content = checkpoints[2].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn4":
                    if (checkpoints[3].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[3].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[3].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[3].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[3].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[3].CheckpointId;
                    LblLandmark.Content = checkpoints[3].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn5":
                    if (checkpoints[4].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[4].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[4].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[4].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[4].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[4].CheckpointId;
                    LblLandmark.Content = checkpoints[4].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn6":
                    if (checkpoints[5].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[5].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[5].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[5].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[5].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[5].CheckpointId;
                    LblLandmark.Content = checkpoints[5].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn7":
                    if (checkpoints[6].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[6].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[6].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[6].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[6].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[6].CheckpointId;
                    LblLandmark.Content = checkpoints[6].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "Btn8":
                    if (checkpoints[7].Drinks == 1)
                    {
                        d = new Feature { feature = "-Стенд для питья" };
                        fList.Add(d);
                    }
                    if (checkpoints[7].EnergyBars == 1)
                    {
                        d = new Feature { feature = "- Энергитические батончики\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[7].Information == 1)
                    {
                        d = new Feature { feature = "- Информационный стенд\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[7].Toilets == 1)
                    {
                        d = new Feature { feature = "- Туалеты\n" };
                        fList.Add(d);
                    }
                    if (checkpoints[7].Medical == 1)
                    {
                        d = new Feature { feature = "- Медицинский пункт\n" };
                        fList.Add(d);
                    }

                    lblCheckid.Content = "Checkpoint " + checkpoints[7].CheckpointId;
                    LblLandmark.Content = checkpoints[7].Landmark;
                    FeaturesList.ItemsSource = fList;
                    break;
                case "BtnStart1":
                    lblCheckid.Content = "Race start \n" + lastMarathon;
                    LblLandmark.Content= " Full Marathon";
                    d = new Feature();
                    FeaturesList.ItemsSource = fList;
                    break;
                case "BtnStart2":
                    lblCheckid.Content = "Race start \n" + lastMarathon;
                    LblLandmark.Content = " Half Marathon";
                     d = new Feature();
                    FeaturesList.ItemsSource = fList;
                    break;
                case "BtnStart3":
                    lblCheckid.Content = "Race start \n" + lastMarathon;
                    LblLandmark.Content = " 5km Fun Run Marathon";
                     d = new Feature();
                    FeaturesList.ItemsSource = fList;
                    break;

                    #endregion
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinAboutMarathon().Show();
            Close();
        }

        public class Feature
        {
            public string feature { get; set; }
            public BitmapImage img { get; set; }
        }
    }
}
