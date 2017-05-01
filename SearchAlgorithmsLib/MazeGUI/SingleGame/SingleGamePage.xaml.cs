using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SingleGamePage.xaml
    /// </summary> 
    public delegate void myfunc();
    
    public partial class SingleGamePage : Page
    {
      public event myfunc X;
        

        public SingleGamePage()
        {
            InitializeComponent();
            //Maze m = new Maze(12, 12);
            //StackPanel.Children.Add(m);
            
        }

     
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            CheckChoice areYouSure = new CheckChoice();
            if (areYouSure.ShowDialog() == true)
            {
                //X += reset();

            }
        }
        public void reset()
        {
            InitializeComponent();
        }
        public void activatePressed()
        {
            X();

        }
        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenuPage.xaml", UriKind.Relative));
        }
    }
}
