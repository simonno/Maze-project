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
using System.Windows.Data;

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
            SetBinding(YouWonProperty, new Binding("YouWon"));
        }



        public bool YouWon
        {
            get { return (bool)GetValue(YouWonProperty); }
            set { SetValue(YouWonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YouWon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YouWonProperty =
            DependencyProperty.Register("YouWon", typeof(bool), typeof(SinglePlayer), new PropertyMetadata(false, OnYouWonPropertyChanged));

        private static void OnYouWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SinglePlayer win = (SinglePlayer)d;
            win.OnYouWonPropertyChanged();
        }

        private void OnYouWonPropertyChanged()
        {
            if (YouWon == true)
            {
                PopMessage youWonMessage = new PopMessage("You Won", "Keep playing", "Return to main menu");
                if (youWonMessage.ShowDialog() != true)
                {
                    if (youWonMessage.Choose == true) //solve the game
                    {
                        BackToMainMenu();
                    }
                }
            }
            YouWon = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            PopMessage resetMessage = new PopMessage("Do you want to reset this maze?", "No", "Yes");
            if (resetMessage.ShowDialog() != true)
            {
                if (resetMessage.Choose == true) //reset the game
                {
                    vm.Reset();
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
                    vm.Solve();
                }
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            BackToMainMenu();
        }

        private void BackToMainMenu()
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
                    vm.MovePlayer(Direction.Right);
                    break;

                case Key.Left:
                    vm.MovePlayer(Direction.Left);
                    break;
            }
        }
    }
}