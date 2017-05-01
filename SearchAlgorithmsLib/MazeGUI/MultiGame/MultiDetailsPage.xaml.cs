using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiDetailsPage.xaml
    /// </summary>
    public partial class MultiDetailsPage : Page
    {
        public MultiDetailsPage()
        {
            InitializeComponent();
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MultiGame/MultiPlayerGame.xaml", UriKind.Relative));
        }
    }
}
