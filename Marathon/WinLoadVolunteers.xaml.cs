using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WinLoadVolunteers.xaml
    /// </summary>
    public partial class WinLoadVolunteers : Window
    {
        public WinLoadVolunteers()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
        }
        int newVolunt = 0;
        int updVolunt = 0;

        string fileName = "";

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            string[] volunteersList = File.ReadAllLines(fileName);
            Regex reg = new Regex(@"[0-9]");
            try
            {
                using (var db = new MarathonDBEntities1())
                {
                    foreach (var volunteer in volunteersList)
                    {
                        string[] volunteerInfo = volunteer.Split(',');
                        Match match = reg.Match(volunteerInfo[0]);
                        if (match.Success)
                        {
                            int id = Convert.ToInt32(volunteerInfo[0]);
                            var vol = db.Volunteer.FirstOrDefault(v => v.VolunteerId == id);
                       

                            if (volunteerInfo[1] == "" || volunteerInfo[1] == null)
                            {
                                MessageBox.Show("Не указанор имя");
                                return;
                            }
                            if (volunteerInfo[2] == "" || volunteerInfo[2] == null)
                            {
                                MessageBox.Show("Не указана фамилия");
                                return;
                            }
                            if (volunteerInfo[3] == "" || volunteerInfo[3] == null)
                            {
                                MessageBox.Show("не указана страна");
                                return;
                            } 
                            if (volunteerInfo[4] == "F") volunteerInfo[4] = "Female";
                            else if (volunteerInfo[4] == "M") volunteerInfo[4] = "Male";
                            else
                            {
                                MessageBox.Show("В файле указан неверный пол");
                                return;
                            }
                            if (vol == null)
                            {
                                Volunteer vol1 = new Volunteer();
                                vol1.FirstName = volunteerInfo[1];
                                vol1.LastName = volunteerInfo[2];
                                vol1.CountryCode = volunteerInfo[3];
                                vol1.Gender = volunteerInfo[4];
                                db.Volunteer.Add(vol1);
                                newVolunt++;
                            }
                            vol = new Volunteer();
                            vol.FirstName = volunteerInfo[1];
                            vol.LastName = volunteerInfo[2];
                            vol.CountryCode = volunteerInfo[3];
                            vol.Gender= volunteerInfo[4];
                            updVolunt++;
                            db.SaveChanges();

                    }
                }
                    MessageBox.Show("Изменения внесены успешно\n"+updVolunt+" волонтеров обновлено\n"+newVolunt+" волонтеров добавлено");
                    newVolunt = 0;
                    updVolunt = 0;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

            #region Управление окном(назад,логаут)

            private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinVolunteers().Show();
            Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        #endregion

        private void BtnFileFind_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV файл *.csv|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                TxtSource.Text = openFileDialog.FileName.Split('\\').Last().ToString();
                fileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }

        }
    }
}
