using System.Windows;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayerDetails.xaml
    /// </summary>
    public partial class MultiPlayerDetails : Window
    {
        private MultiPlayerDetailsViewModel vm;
        public MultiPlayerDetails()
        {
            InitializeComponent();
            vm = new MultiPlayerDetailsViewModel();
            DataContext = vm;
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayer win = new MultiPlayer()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }
    }
}
