using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SingleGamePage.xaml
    /// </summary> 

    public partial class SingleGamePage : Page
    {
        //public event myfunc X;
        public SingleGamePage()
        {
            InitializeComponent();
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            AskToExit areYouSure = new AskToExit();
            if (areYouSure.ShowDialog() != true) {
                if (areYouSure.choose==true)//exit the game
                {
                    Reset();
                }
            }
        }
        public void Reset()
        {
            InitializeComponent();
        }
     
        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            AskToSolve areYouSure = new AskToSolve();
            if (areYouSure.ShowDialog() != true)
            {
                if (areYouSure.choose == true)//solve the game
                {
                    solveMaze();
                }
            }
        }

        private void solveMaze()
        {
           //TO DO solve maze 
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenuPage.xaml", UriKind.Relative));
        }
    }
}
