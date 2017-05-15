using System.Windows;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayerDetails.xaml
    /// </summary>
    public partial class MultiPlayerDetails : Window
    {
        public MultiPlayerDetails()
        {
            InitializeComponent();
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
