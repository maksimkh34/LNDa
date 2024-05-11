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
    /// Логика взаимодействия для FileHandlerWindow.xaml
    /// </summary>
    public partial class FileHandlerWindow : Window
    {
        public FileHandlerWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            App.incomingFileDialogResult = App.IncomingFileDialogResult.OpenFile;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            App.incomingFileDialogResult = App.IncomingFileDialogResult.SaveFile;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
