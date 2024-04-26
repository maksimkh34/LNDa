using AtomicBackuper;
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
using System.Windows.Shapes;

namespace LNDa
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => DragMove();
        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_TopBar_Click(object sender, RoutedEventArgs e) => Close();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.UserName = NameTextBox.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = App.UserName;
        }
    }
}
