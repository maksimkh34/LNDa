using LNDa;
using System.Windows;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        public DisplayWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => DragMove();
        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_TopBar_Click(object sender, RoutedEventArgs e) => Close();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Loaded(object sender, RoutedEventArgs e) => mainTb.Text = App.GetDisplayMsg();
    }
}
