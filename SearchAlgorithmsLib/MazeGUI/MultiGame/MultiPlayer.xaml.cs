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

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        private MultiPlayerViewModel vm;
        public MultiPlayer(IMultiPlayerModel model)
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(model);
            DataContext = vm;
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_OpponentPosChanged")
                    MoveOppenent();
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
                    break;

                case Key.Down:
                    myBoard.MoveDown();
                    break;

                case Key.Right:
                    myBoard.MoveRight();
                    break;

                case Key.Left:
                    myBoard.MoveLeft();
                    break;
            }

        }
    }
}
