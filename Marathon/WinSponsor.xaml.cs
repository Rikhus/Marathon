using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для WinSponsor.xaml
    /// </summary>
    public partial class WinSponsor : Window
    {
        int Money=50;
        int RegistrationId;
       
        public WinSponsor()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadRunner();
            CharityInform.CharityName = "";
            CharityInform.CharityDesc = "";
            CmbRunners.SelectedIndex = 0;
        }

        public void LoadRunner()
        {
            using (var db = new MarathonDBEntities1())
            {
                var MarathonCount = db.MarathonTbl.Count();
                var LastMarathon = db.MarathonTbl.FirstOrDefault(u => u.MarathonId == MarathonCount);

                var RunnerList = (from r in db.Runner
                                  join u in db.User on r.Email equals u.Email
                                  join c in db.Country on r.CountryCode equals c.CountryCode
                                  join reg in db.Registration on r.RunnerId equals reg.RunnerId
                                  join regEvent in db.RegistrationEvent on reg.RegistrationId equals regEvent.RegistrationId
                                  join e in db.Event on regEvent.EventId equals e.EventId
                                  orderby u.FirstName
                                  where e.MarathonId == LastMarathon.MarathonId
                                  select new
                                  {
                                      Id = reg.RegistrationId,
                                      Name = u.FirstName + " " + u.LastName + " -" + regEvent.BibNumber + " (" + c.CountryName + ")"
                                  }).ToList();

                CmbRunners.ItemsSource = RunnerList;
                CmbRunners.DisplayMemberPath = "Name";
                CmbRunners.SelectedValuePath = "Id";
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
      
        private void BtnPlusMoney_Click(object sender, RoutedEventArgs e)
        {
            Money+= 10;
            txtMoney.Text = Money.ToString();
            lblMoney.Content = Money.ToString()+"$";
        }

        private void BtnMinusMoney_Click(object sender, RoutedEventArgs e)
        {
            Money -= 10;
            txtMoney.Text = Money.ToString();
            lblMoney.Content = Money.ToString() + "$";
        }

        private void TxtMoney_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                Money = Int32.Parse(txtMoney.Text);
                lblMoney.Content = Money.ToString() + "$";
            }
            catch
            {
                if (txtMoney.Text != "")
                {
                    MessageBox.Show("Недопустимое значение");
                    Money = 50;
                    txtMoney.Text = Money.ToString();
                    lblMoney.Content = Money.ToString() + "$";
                }
                else
                {
                    lblMoney.Content = "$";
                }
            }
        }      

        private void CmbRunners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int runnerId = Convert.ToInt32(CmbRunners.SelectedValue);
            using (var db = new MarathonDBEntities1())
            {
                var CharityInf = db.Registration.FirstOrDefault(r => r.RunnerId == runnerId);
                CharityInform.CharityName = CharityInf.Charity.CharityName;
                CharityInform.CharityDesc = CharityInf.Charity.CharityDescription;
                LblCharityName.Content = CharityInf.Charity.CharityName;
            }
        }

        private void BtnCharityInfo_Click(object sender, RoutedEventArgs e)
        {
            if (CharityInform.CharityName != "")
            {
                MessageBox.Show(CharityInform.CharityDesc);
            }
            else
            {
                MessageBox.Show("Выберите бегуна");
            }
        }
        
        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "" && TxtName.Text != " " && TxtCardInf.Text != "" && TxtCardInf.Text != " " && Money>0 && CmbRunners.SelectedIndex>-1)
            {
                try
                {
                    Int32.Parse(TxtMonth.Text);
                    Int32.Parse(TxtYear.Text);
                    Int64.Parse(TxtCardNum.Text);
                    Int32.Parse(TxtCVC.Text);
                }
                catch
                {
                    MessageBox.Show("Поля не заполнены или не верный тип данных");
                    return;
                }

                if (TxtCardNum.Text.Length<16)
                {
                    MessageBox.Show("Номер карты должен содержать 16 цифр!");
                    return;
                }

                if (Convert.ToInt32(TxtMonth.Text)>12 || Convert.ToInt32(TxtMonth.Text)<1)
                {
                    MessageBox.Show("Неверный месяц");
                    return;
                }

                if (Convert.ToInt32(TxtYear.Text) < 2016 || Convert.ToInt32(TxtYear.Text) > 3000)
                {
                    MessageBox.Show("Неверный год");
                    return;
                }

                DateTime startTime = new DateTime(Convert.ToInt32(TxtYear.Text),Convert.ToInt32(TxtMonth.Text), 1);
                DateTime now = DateTime.Now;
                TimeSpan span = startTime.Subtract(now);

                if (span.Days<=0)
                {
                    MessageBox.Show("Карта не активна");
                    return;
                }

                if (TxtCVC.Text.Length < 3)
                {
                    MessageBox.Show("CVC карты должен содержать 3 цифры!");
                    return;
                }

                using (var DataBase = new MarathonDBEntities1())
                {
                    Sponsorship Sponsor = new Sponsorship
                    {
                        SponsorName = TxtName.Text,
                        RegistrationId = Convert.ToInt32(CmbRunners.SelectedValue),
                        Amount = Convert.ToDecimal(Money)
                    };

                    DataBase.Sponsorship.Add(Sponsor);
                    DataBase.SaveChanges();
                }

                LocalStorage.SelectedRunnerForSponsorShip.Amount = Money;
                LocalStorage.SelectedRunnerForSponsorShip.CharityName = CharityInform.CharityName;

                new WinSponsorThanks().Show();
                Close();
                
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
                return;
            }
        }

        class CharityInform
        {
            public static string CharityName { get; set; }
            public static string CharityDesc { get; set; }
        }

        private void TextInputNumber(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void TextInputName(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"[^a-z | а-я]+", RegexOptions.IgnoreCase);
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
