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
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        

        public WinLogin()
        {
            InitializeComponent();
            TimeCalc();
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string roleid = Login();
            if (roleid!=null)
            {
                if (roleid == "R")
                {
                    new WinRunnerMenu().Show();
                    Close();
                }
            }
        }    
                
        private void TxtLogin_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (TxtLogin.Text == "Адрес электронной почты")
            {
                TxtLogin.Clear();
                TxtLogin.Foreground = Brushes.Black;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtLogin.Text))
                {
                    TxtLogin.Foreground = Brushes.Gray;
                    TxtLogin.Text = "Адрес электронной почты";
                }
            }
        }

        public void TimeCalc()
        {
            DateTime startTime = new DateTime(2019, 9, 21);
            DateTime now = DateTime.Now;
            TimeSpan span = startTime.Subtract(now);
            LblTime.Content = "Осталось " + span.Days + " дней " + span.Hours + " часов " + span.Minutes + " минут.";
        }

        public string Login()
        {
            using (var db = new MarathonDBEntities1())
            {
                
                var user = db.User.FirstOrDefault(u => u.Email == TxtLogin.Text && u.Password == PassBox.Password);
                if (user != null)
                {        
                    
                    return user.RoleId;
                }
                return null;


            }
        }
    }
}
