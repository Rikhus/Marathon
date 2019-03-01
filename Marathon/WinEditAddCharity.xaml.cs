using Microsoft.Win32;
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
using System.IO;
using System.Reflection;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для WinEditAddCharity.xaml
    /// </summary>
    public partial class WinEditAddCharity : Window
    {
        public WinEditAddCharity()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            if(LocalStorage.CharityClass.CharityName!="" && LocalStorage.CharityClass.CharityName != " " && LocalStorage.CharityClass.CharityName!=null)
            {
                TxtName.Text = LocalStorage.CharityClass.CharityName;
                TxtDesc.Text = LocalStorage.CharityClass.CharityDesc;
                TxtSource.Text = LocalStorage.CharityClass.CharityLogo;
                string path = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", TxtSource.Text);
                ImgLogo.Source = new BitmapImage(new Uri(path));
            }
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinCharitiesManage().Show();
            Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnFileFind_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Изображение *.jpg;*.png | *.jpg;*.png";
            if (openFileDialog.ShowDialog()==true)
            {
                ImgLogo.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                TxtSource.Text = openFileDialog.FileName;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            #region Проверка заполнения полей

            if (TxtName.Text=="" || TxtName.Text==" ")
            {
                MessageBox.Show("Заполните наименование организации");
                return;
            }
            if (TxtDesc.Text == "" || TxtDesc.Text == " ")
            {
                MessageBox.Show("Заполните описание организации");
                return;
            }
            if (TxtSource.Text == "")
            {
                MessageBox.Show("Установите логотип организации");
                return;
            }

            #endregion

            #region Если создаем организацию

            if (LocalStorage.CharityClass.CharityId == "" || LocalStorage.CharityClass.CharityId == null || LocalStorage.CharityClass.CharityId == " ")
            {
                Charity charity = new Charity();
                charity.CharityName = TxtName.Text;
                charity.CharityDescription = TxtDesc.Text;
                string[] fileName = TxtSource.Text.Split('\\');
                string way = Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\Marathon.exe", "CharityLogos\\" + fileName[fileName.Length - 1]);
                File.Copy(TxtSource.Text, way, true);
                charity.CharityLogo = fileName[fileName.Length - 1];
                try
                {
                    using (var db = new MarathonDBEntities1())
                    {
                        db.Charity.Add(charity);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            #endregion

            #region Если редачим существующую организацию

            else
            {
                try
                {
                    using (var db = new MarathonDBEntities1())
                    {
                        var charityOrg = db.Charity.FirstOrDefault(c=>c.CharityId.ToString()==LocalStorage.CharityClass.CharityId);
                        charityOrg.CharityName = TxtName.Text;
                        charityOrg.CharityDescription = TxtDesc.Text;
                        charityOrg.CharityLogo = LocalStorage.CharityClass.CharityLogo.Replace("CharityLogos/","");
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            #endregion
            MessageBox.Show("Изменения внесены успешно!");


        }
    }
}
