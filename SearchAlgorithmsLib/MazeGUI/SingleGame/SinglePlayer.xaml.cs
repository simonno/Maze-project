using ClientLib;
using System.Windows;
using System.Configuration;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System;
using System.Windows.Threading;
using MazeLib;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private DispatcherTimer timer = null;

        private SinglePlayerViewModel vm;

        public SinglePlayer(string mazeName, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new ApplicationSinglePlayerModel(mazeName, rows, cols));
            DataContext = vm;
            timer = new DispatcherTimer();
            timer.IsEnabled = false;
        }


        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            PopMessage resetMessage = new PopMessage("Do you want to reset this maze?", "No", "Yes");
            if (resetMessage.ShowDialog() != true)
            {
                if (resetMessage.Choose == true) //reset the game
                {
                    //mazeBoard.MoveBackToTheStart();
                }
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            PopMessage solveMessage = new PopMessage("Do you want to solve this maze?", "No", "Yes");
            if (solveMessage.ShowDialog() != true)
            {
                if (solveMessage.Choose == true) //solve the game
                {
                    //var result =  SolveMaze();
                }
            }
        }
        //private async Task<string> SolveMaze()
        //{
        //    btnReset.IsEnabled = false;
        //    btnSolve.IsEnabled = false;
        //    mazeBoard.MoveBackToTheStart();
        //    string solveString = vm.s();
        //    int i = 0;
        //    while (i < solveString.Length)
        //    {
        //        switch (solveString[i])
        //        {
        //            case 'U':
        //                mazeBoard.MoveUp();
        //                break;

        //            case 'D':
        //                mazeBoard.MoveDown();
        //                break;

        //            case 'R':
        //                mazeBoard.MoveRight();
        //                break;

        //            case 'L':
        //                mazeBoard.MoveLeft();
        //                break;
        //        }
        //        await Task.Delay(500);
        //        i++;
        //    }
        //    btnReset.IsEnabled = true;
        //    btnSolve.IsEnabled = true;
        //    return "Success";
        //}
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
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
                    vm.MovePlayer(Direction.Up);
                    break;

                case Key.Down:
                    vm.MovePlayer(Direction.Down);
                    break;

                case Key.Right:
                    vm.MovePlayer(Direction.Left);
                    break;

                case Key.Left:
                    vm.MovePlayer(Direction.Right);
                    break;
            }


        }
    }
}


