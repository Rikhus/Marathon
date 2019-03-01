using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для WinAboutMarathon.xaml
    /// </summary>
    public partial class WinAboutMarathon : Window
    {
        
        public WinAboutMarathon()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            Load();
        }
        

        private void Load()
        {
            try
            {
                string way = Assembly.GetExecutingAssembly().Location.Replace("Marathon.exe", "marathon-skills-2016-marathon-info.txt");
                TxtInf.Text= File.ReadAllText(way);
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

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            new WinInteractiveMap().Show();
            Close();
        }
    }
}
