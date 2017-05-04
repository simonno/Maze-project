using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MazeGUI.SingleGame;
using System.Windows.Media.Imaging;

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
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("SingleGame/SingleDetailsPage.xaml", UriKind.Relative));
            //SingleDetailsPage menu = new SingleDetailsPage();
            //menu.ShowDialog();
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MultiGame/MultiDetailsPage.xaml", UriKind.Relative));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Settings/SettingsPage.xaml", UriKind.Relative));
        }

        //private void Image_Loaded(object sender, RoutedEventArgs e)
        //{
        //    BitmapImage b = new BitmapImage();
        //    b.BeginInit();
        //    b.UriSource = new Uri("Images/mazeLogo.png", UriKind.Relative);
        //    b.EndInit();

        //    // ... Get Image reference from sender.
        //    var image = sender as Image;
        //    // ... Assign Source.
        //    image.Source = b;
        //}
    }
}
