using Project;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LNDa
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string display_msg = "$UNDEFINED$";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            TestFunc();
        }

        internal static string GetDisplayMsg() => display_msg;

        internal static void DisplayMessage(string text)
        {
            display_msg = text;
            new DisplayWindow().ShowDialog();
            display_msg = "$UNDEFINED$";
        }

        internal static void TestFunc()
        {
        }

        public static void DefaultDataRecived(string data)
        {
            return;
        }

    }
}
