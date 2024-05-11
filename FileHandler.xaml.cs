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
    /// Логика взаимодействия для FileHandler.xaml
    /// </summary>
    public partial class FileHandler : Window
    {
        public FileHandler()
        {
            InitializeComponent();
        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => DragMove();
        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_TopBar_Click(object sender, RoutedEventArgs e) => Close();
    }
}
