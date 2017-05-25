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
        private MultiPlayerViewModel vm;
        public MultiPlayer(IMultiPlayerModel model)
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(model);
            DataContext = vm;
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
            
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            PopMessage exitMessage = new PopMessage("Do you want to exit this maze?", "No", "Yes");
            if (exitMessage.ShowDialog() != true)
            {
                if (exitMessage.Choose == true) //reset the game
                {
                    vm.Close();
                    MainWindow win = new MainWindow()
                    {
                        Top = Top,
                        Left = Left
                    };
                    win.Show();
                    Close();

                }
            }
        }

        private  void Window_KeyDown(object sender, KeyEventArgs e)
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
        //void timer_Tick(object sender, EventArgs e)
        //{
        //}
    }
}
