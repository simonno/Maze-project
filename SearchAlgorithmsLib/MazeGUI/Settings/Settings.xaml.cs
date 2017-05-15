using System.Windows;

namespace MazeGUI.Settings
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsViewModel vm;


        public Settings()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new ApplicationSettingsModel());
            DataContext = vm;        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Top = Top;
            win.Left = Left;
            win.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            MainWindow win = new MainWindow();
            win.Top = Top;
            win.Left = Left;
            win.Show();
            this.Close();
        }
    }
}
