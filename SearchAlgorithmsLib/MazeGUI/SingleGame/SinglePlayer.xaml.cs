using ClientLib;
using System.Windows;
using System.Configuration;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System;
using System.Windows.Threading;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private System.Windows.Threading.DispatcherTimer _timer = null;

        private SinglePlayerViewModel vm;

        public SinglePlayer(string mazeName, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new ApplicationSinglePlayerModel(mazeName, rows, cols));
            DataContext = vm;
            //MessageBox.Show("rows:" + mazeBoard.Rows + " , cols:" + mazeBoard.Cols);
            _timer = new DispatcherTimer();
            _timer.IsEnabled = false;
            _timer.Tick += new System.EventHandler(MoveTo);
        }
    

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            PopMessage resetMessage = new PopMessage("Do you want to reset this maze?", "No", "Yes");
            if (resetMessage.ShowDialog() != true)
            {
                if (resetMessage.Choose == true) //reset the game
                {
                    Reset();
                }
            }
        }
        public void Reset()
        {
            InitializeComponent();
            mazeBoard.PlayerPos = mazeBoard.PlayerStartPoint;
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            PopMessage solveMessage = new PopMessage("Do you want to solve this maze?", "No", "Yes");
            if (solveMessage.ShowDialog() != true)
            {
                if (solveMessage.Choose == true) //solve the game
                {
                    var result =   SolveMaze();
                }
            }
        }

        private async Task<string> SolveMaze()
        {
            Reset();
            string solveString = vm.s();
            int i = 0;
            while (i < solveString.Length)
            {
                switch (solveString[i])
                {
                    case 'U':
                        //MessageBox.Show("up1");
                        mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y - 1);
                        break;

                    case 'D':
                        //MessageBox.Show("down1");
                        mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y + 1);
                        break;

                    case 'R':
                        //MessageBox.Show("right1");
                        mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X + 1, mazeBoard.PlayerPos.Y);
                        break;

                    case 'L':
                        //MessageBox.Show("left1");
                        mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X - 1, mazeBoard.PlayerPos.Y);
                        break;
                }
                await Task.Delay(1000);
                i++;
            }
            return "Success";
        }

        private void MoveTo(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                Reset();
                string solveString = vm.s();
                int i = 0;
                while (i < solveString.Length)
                {
                    switch (solveString[i])
                    {
                        case 'U':
                            //MessageBox.Show("up1");
                            mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y - 1);
                            break;

                        case 'D':
                            //MessageBox.Show("down1");
                            mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y + 1);
                            break;

                        case 'R':
                            //MessageBox.Show("right1");
                            mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X + 1, mazeBoard.PlayerPos.Y);
                            break;

                        case 'L':
                            //MessageBox.Show("left1");
                            mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X - 1, mazeBoard.PlayerPos.Y);
                            break;
                    }

                    i++;

                }
            })); 
            
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
                    //MessageBox.Show("up1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y - 1);
                    break;

                case Key.Down:
                    //MessageBox.Show("down1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X, mazeBoard.PlayerPos.Y + 1);
                    break;

                case Key.Right:
                    //MessageBox.Show("right1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X + 1, mazeBoard.PlayerPos.Y);
                    break;

                case Key.Left:
                    //MessageBox.Show("left1");
                    mazeBoard.PlayerPos = new Controls.MazeBoard.Point(mazeBoard.PlayerPos.X - 1, mazeBoard.PlayerPos.Y);
                    break;
            }
        }
    }
}


