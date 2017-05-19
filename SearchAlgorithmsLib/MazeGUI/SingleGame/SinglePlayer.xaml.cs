using ClientLib;
using System.Windows;
using System.Configuration;
using System.Windows.Input;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerViewModel vm;

        public SinglePlayer(string mazeName, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new ApplicationSinglePlayerModel(mazeName, rows, cols));
            DataContext = vm;
            //MessageBox.Show("rows:" + mazeBoard.Rows + " , cols:" + mazeBoard.Cols);
            
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
            //MessageBox.Show("rows:" + mazeBoard.Rows + " , cols:" + mazeBoard.Cols + mazeBoard.Maze);
            MainWindow win = new MainWindow()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    MessageBox.Show("up1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y - 1);
                    break;

                case Key.Down:
                    MessageBox.Show("down1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y + 1);
                    break;

                case Key.Right:
                    MessageBox.Show("right1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X + 1, mazeBoard.PlayerPos.Y);
                    break;

                case Key.Left:
                    MessageBox.Show("left1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X - 1, mazeBoard.PlayerPos.Y);
                    break;
            }
        }
    }
}
