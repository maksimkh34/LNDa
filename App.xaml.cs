using AtomicBackuper;
using Project;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace LNDa
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal enum IncomingFileDialogResult {
            OpenFile,
            SaveFile,
            Ignore
        }

        internal static IncomingFileDialogResult incomingFileDialogResult = IncomingFileDialogResult.Ignore;
        internal static string UserName = "";
        internal readonly static string PROGRAM_PATH = Environment.GetEnvironmentVariable("LocalAppData") + "\\LDNa\\";
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

        /*
         *      Name ReQuest
         *      nrq=192.168.100.156
         *      nrq=[IP отправителя запроса]
         * 
         *      Name ReSponse
         *      nrp=Иван=192.168.100.141
         *      nrp=[Свое имя]=[Свой IP]
         * 
         *      file=FileName.Type
         *      [data]
         *      
         *      file=README.md
         *      text
         * 
         */


        public static void MainDataRecived(string data)
        {
            string FirstLine = data.Split('\n')[0];
            if(FirstLine.StartsWith("nrq"))
            {
                LocalNetworkDataAdapter.SendData(FirstLine.Split('=')[1], "nrp=" + UserName + "=" + LocalNetworkDataAdapter.GetLocalIP()); return;
            }

            if(FirstLine.StartsWith("nrp"))
            {
                IpToName.Add(FirstLine.Split('=')[1], FirstLine.Split('=')[2]); return;
            }

            if(FirstLine.StartsWith("file")) {
                FileHandlerClass.FileHandler(FirstLine.Split('=')[1], data.Replace(FirstLine, ""));
            }
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

        static void HandleFile(string FileExtension, string data)
        {
            // new FileHandlerWindow().ShowDialog();
            if(incomingFileDialogResult == IncomingFileDialogResult.Ignore)
            {
                return;
            } else
            {
                string FilePath = "test";
                // Get File Path
                FilePath.Replace(FilePath.Split('.')[FilePath.Length - 1], "");
                FilePath += FileExtension;

                StreamWriter writer = new StreamWriter(FilePath);
                writer.Write(data);
                writer.Close();
            }
            incomingFileDialogResult = IncomingFileDialogResult.Ignore;
        }
    }
}
