using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Marathon
{
    static class LocalStorage
    {
        public static string previewWindow { get; set; }
        public class SelectedRunnerForSponsorShip
        {
            public static string Runner { get; set; }
            public static int Amount { get; set; }
            public static string CharityName { get; set; }
        }

        public static void TimeCalc(Label lbl)
        {
            DateTime startTime = new DateTime(2019, 9, 21);
            DateTime now = DateTime.Now;
            TimeSpan span = startTime.Subtract(now);
            lbl.Content = "Осталось " + span.Days + " дней " + span.Hours + " часов " + span.Minutes + " минут.";
        }
        public class UserClass
        {
            public static string Email { get; set; }
            public static string FirstName { get; set; }
            public static string LastName { get; set; }
        }
        
            
        
    }
    

    
    
}
