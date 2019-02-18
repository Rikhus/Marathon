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
            LocalStorage.TimeCalc(LblTime);

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TxtLogin.Text == "Адрес электронной почты")
            {
                WinSelectRoleDebug winDebug = new WinSelectRoleDebug();
                winDebug.Owner = this;
                winDebug.Show();

            }
            string roleid = Login();
            if (roleid!=null)
            {
                if (roleid == "R")
                {
                    new WinRunnerMenu().Show();
                    Close();
                }
                if (roleid == "C")
                {
                    new WinCoordinatorMenu().Show();
                    Close();
                }
                if (roleid == "A")
                {
                    new WinAdminMenu().Show();
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

        

        public string Login()
        {
            try
            {
                using (var db = new MarathonDBEntities1())
                {


                    var user = db.User.FirstOrDefault(u => u.Email == TxtLogin.Text && u.Password == PassBox.Password);
                    LocalStorage.UserClass.Email = user.Email;
                    LocalStorage.UserClass.FirstName = user.FirstName;
                    LocalStorage.UserClass.LastName = user.LastName;
                    LocalStorage.UserClass.RunnerId = user.Runner.FirstOrDefault(u=>u.Email==user.Email).RunnerId.ToString();
                    if (user != null)
                    {

                        return user.RoleId;
                    }
                    return null;


                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Неверный логин или пароль");
                return null;
            }
        }
    }
}
