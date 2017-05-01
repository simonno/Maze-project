using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MazeGUI.SingleGame;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private NavigationService ns;
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            //ns = NavigationService.GetNavigationService(this);
            //ns.Navigate(new Uri("SingleDetailsPage.xaml", UriKind.Relative));
            SingleDetailsPage menu = new SingleDetailsPage();
            menu.ShowDialog();
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MultiDetailsPage.xaml", UriKind.Relative));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Settings/SettingsPage.xaml", UriKind.Relative));
        }
    }
}
