using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private Dispatcher d;

        private MultiPlayerViewModel vm;
        public MultiPlayer(IMultiPlayerModel model)
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(model);
            DataContext = vm;
            d = Dispatcher.CurrentDispatcher;
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                opponentBoard.Player.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    if (e.PropertyName == "VM_OpponentPosChanged")
                        MoveOppenent();
                }));
            };
        }

        private void MoveOppenent()
        {
            switch (vm.OpponentPosChanged)
            {
                case Direction.Up:
                    opponentBoard.MoveUp();
                    break;

                case Direction.Down:
                    opponentBoard.MoveDown();
                    break;

                case Direction.Right:
                    opponentBoard.MoveRight();
                    break;

                case Direction.Left:
                    opponentBoard.MoveLeft();
                    break;
            }
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
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
                    myBoard.MoveUp();
                    vm.Play(Direction.Up);
                    break;

                case Key.Down:
                    myBoard.MoveDown();
                    vm.Play(Direction.Down);
                    break;

                case Key.Right:
                    myBoard.MoveRight();
                    vm.Play(Direction.Right);
                    break;

                case Key.Left:
                    myBoard.MoveLeft();
                    vm.Play(Direction.Left);
                    break;
            }

        }
    }
}
