using ClientLib;
using System.Windows;
using System.Configuration;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        public SinglePlayer()
        {
            InitializeComponent();
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            Client client = new Client(ip, port);

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            AskToExit areYouSure = new AskToExit();
            if (areYouSure.ShowDialog() != true)
            {
                if (areYouSure.choose == true) //resey the game
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
                if (areYouSure.choose == true) //solve the game
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
            MainWindow win = new MainWindow();
            win.Top = Top;
            win.Left = Left;
            win.Show();
            this.Close();
        }
    }
}
