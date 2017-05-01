using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SingleDetailsPage.xaml
    /// </summary>
    public partial class SingleDetailsPage : Window
    {
        public SingleDetailsPage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = MazeDetails.txtBoxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please insert a name for the maze");
                return;
            }

            string rows = MazeDetails.txtBoxRows.Text;
            if (string.IsNullOrEmpty(rows))
            {
                MessageBox.Show("Please insert the number of the maze's rows.");
                return;
            }

            string columns = MazeDetails.txtBoxColumns.Text;
            if (string.IsNullOrEmpty(columns))
            {
                MessageBox.Show("Please insert the number of the maze's columns.");
                return;
            }


            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("SingleGamePage.xaml", UriKind.Relative));
        }
    }
}
