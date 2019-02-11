using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Marathon
{
    static class LocalStorage
    {
        public static string previewWindow { get; set; }

        
    }

    public class Utils: Window
    {
        public static object CreatePreviousWindow(string CurrentWin)
        {
            Type t = Type.GetType("Marathon." + LocalStorage.previewWindow);
            if (t == null || LocalStorage.previewWindow == CurrentWin)
            {
                t = Type.GetType("Marathon.MainWindow");
            }
            return Activator.CreateInstance(t);
        }
    }
    
}
