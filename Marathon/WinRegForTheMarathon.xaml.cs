using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WinRegForTheMarathon.xaml
    /// </summary>
    public partial class WinRegForTheMarathon : Window
    {
        private char SelectedId; 
        private List<string> EventType = new List<string>();
        private int Money=0;

        public IOrderedEnumerable<Charity> Charities { get; set; }

        public WinRegForTheMarathon()
        {
            InitializeComponent();
            LocalStorage.TimeCalc(LblTime);
            LoadCharity();
        }

        public void LoadCharity()
        {
            using (var db = new MarathonDBEntities1())
            {
                Charities = db.Charity.ToList().OrderBy(u=> u.CharityName);
                CmbCharity.ItemsSource = Charities;
                CmbCharity.DisplayMemberPath = "CharityName";
                CmbCharity.SelectedValuePath = "CharityId";
                CmbCharity.SelectedIndex = 0;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void ChkFull_Checked(object sender, RoutedEventArgs e)
        {
            Money += 145;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Add("FM");
        }

        private void ChkFull_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 145;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Remove("FM");
        }

        private void ChkHalf_Checked(object sender, RoutedEventArgs e)
        {
            Money += 75;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Add("HM");
        }

        private void ChkHalf_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 75;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Remove("HM");
        }

        private void ChkSmall_Checked(object sender, RoutedEventArgs e)
        {
            Money += 20;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Add("FR");
        }

        private void ChkSmall_Unchecked(object sender, RoutedEventArgs e)
        {
            Money -= 20;
            LblMoney.Content = "$" + Money.ToString();
            EventType.Remove("FR");
        }

        private void Rdbtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Name == "RdbtnA")
            {
                SelectedId = 'A';
            }
            if (pressed.Name == "RdbtnB")
            {
                Money += 20;
                LblMoney.Content = "$" + Money.ToString();
                SelectedId = 'B';
            }
            if (pressed.Name == "RdbtnC")
            {
                Money += 45;
                LblMoney.Content = "$" + Money.ToString();
                SelectedId = 'C';
            }
        }

        private void Rdbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Name == "RdbtnA")
            {

            }
            if (pressed.Name == "RdbtnB")
            {
                Money -= 20;
                LblMoney.Content = "$" + Money.ToString();
            }
            if (pressed.Name == "RdbtnC")
            {
                Money -= 45;
                LblMoney.Content = "$" + Money.ToString();
            }

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ChkFull.IsChecked==false && ChkHalf.IsChecked==false && ChkSmall.IsChecked==false)
                {
                    MessageBox.Show("Должен быть выбран по крайней мере \n   один вид марафона");
                    return;
                }

                Regex reg = new Regex(@"^\d+");
                if(reg.IsMatch(TxtPayment.Text)==false)
                {
                    MessageBox.Show("Неверная сумма взноса");
                    return;
                }
                
                using (var db = new MarathonDBEntities1())
                {
                    Registration registration = new Registration
                    {
                        RunnerId=Convert.ToInt32(LocalStorage.UserClass.RunnerId),
                        RegistrationDateTime = DateTime.Now,
                        RaceKitOptionId = SelectedId.ToString(),
                        RegistrationStatusId = 1,
                        Cost = Money,
                        CharityId = Convert.ToInt32(CmbCharity.SelectedValue),
                        SponsorshipTarget = Convert.ToInt32(TxtPayment.Text)
                    };                    
                    db.Registration.Add(registration);

                    int LastMarathon = db.MarathonTbl.Count();
                    var RegEvent = db.Event.Where(u=>u.MarathonId==LastMarathon);

                    foreach (var item in EventType)
                    {
                        var EventId = db.Event.FirstOrDefault(u=>u.EventTypeId==item && u.MarathonId==LastMarathon);
                        RegistrationEvent regEv = new RegistrationEvent
                        {
                            RegistrationId = registration.RegistrationId,
                            BibNumber = null,
                            RaceTime = null,
                            EventId = EventId.EventId
                        };
                        db.RegistrationEvent.Add(regEv);
                    }

                    db.SaveChanges();
                    new WinRunnerRegThanks().Show();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            new WinRunnerMenu().Show();
            Close();
        }

        private void BtnCharityInf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Charities.FirstOrDefault(c=>c.CharityId==Convert.ToInt32(CmbCharity.SelectedValue)).CharityDescription);
        }

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
