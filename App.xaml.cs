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
        internal static string UserName;
        internal readonly static string program_path = "";
        static string display_msg = "$UNDEFINED$";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //UserName = DataProvider.LoadDataList(App.program_path + "name")[0][0];
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
            DataProvider.WriteDataList(program_path + "name", new List<List<string>>() { new List<string>() { UserName } });
        }
    }
}
