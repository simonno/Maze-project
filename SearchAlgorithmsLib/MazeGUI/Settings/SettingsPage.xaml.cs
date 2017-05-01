using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MazeGUI.Settings
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private NavigationService ns;
        private SettingsViewModel vm;

        public SettingsPage()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new ApplicationSettingsModel());
            DataContext = vm;
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenuPage.xaml", UriKind.Relative));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenuPage.xaml", UriKind.Relative));
        }
    }
}
