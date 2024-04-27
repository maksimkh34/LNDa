using AtomicBackuper;
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
        internal static string UserName = "";
        internal readonly static string PROGRAM_PATH = "C:\\Windows\\Resources\\LNDA\\";
        static string display_msg = "$UNDEFINED$";
        internal static Dictionary<string, string> IpToName = new Dictionary<string, string>();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try { 
                UserName = DataProvider.LoadDataList(PROGRAM_PATH + "name")[0][0];
            }
            catch(ArgumentOutOfRangeException) {
            }
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

        public static void DisplayDataRecived(string data)
        {
            MessageBox.Show("Получены данные: " + data);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DataProvider.WriteDataList(PROGRAM_PATH + "name", new List<List<string>>() { new List<string>() { UserName } });
            Environment.Exit(0);
        }
    }
}
