using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace LNDa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Thread ServerThread = new Thread(new ThreadStart(() => LocalNetworkDataAdapter.StartPolling(App.DisplayDataRecived)));
                ServerThread.Start();
            } catch(LocalNetworkDataAdapter.NetworkInitError)
            {
                App.DisplayMessage("Ошибка инициализации локальной сети. ");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => DragMove();
        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_TopBar_Click(object sender, RoutedEventArgs e) => Close();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SendDataWindow().ShowDialog();
        }
    }
}
