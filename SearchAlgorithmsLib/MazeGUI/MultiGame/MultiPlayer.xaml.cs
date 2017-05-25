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
            SetBinding(YouWonProperty, new Binding("YouWon"));
            SetBinding(OpponentWonProperty, new Binding("OpponentWon"));
            SetBinding(ExitGameProperty, new Binding("ExitGame"));
            SetBinding(LostConnectionProperty, new Binding("LostConnection"));
        }



        public bool LostConnection
        {
            get { return (bool)GetValue(LostConnectionProperty); }
            set { SetValue(LostConnectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LostConnection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LostConnectionProperty =
            DependencyProperty.Register("LostConnection", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnLostConnectionPropertyChanged));

        private static void OnLostConnectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnLostConnectionPropertyChanged();
        }

        private void OnLostConnectionPropertyChanged()
        {
            if (LostConnection == true)
            {
                PopMessage youWonMessage = new PopMessage("You Lost", "Keep playing", "Return to main menu");
                if (youWonMessage.ShowDialog() != true)
                {
                    if (youWonMessage.Choose == true)
                    {
                        BackToMainMenu();
                    }
                }
            }
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }


        public bool ExitGame
        {
            get { return (bool)GetValue(ExitGameProperty); }
            set { SetValue(ExitGameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitGame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitGameProperty =
            DependencyProperty.Register("ExitGame", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnExitGamePropertyChanged));

        private static void OnExitGamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnExitGamePropertyChanged();
        }

        private void OnExitGamePropertyChanged()
        {
            if (ExitGame == true)
            {
                MessageBox.Show("Opponent close the game.");
            }
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }

        public bool YouWon
        {
            get { return (bool)GetValue(YouWonProperty); }
            set { SetValue(YouWonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YouWon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YouWonProperty =
            DependencyProperty.Register("YouWonMultiPlayer", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnYouWonPropertyChanged));

        private static void OnYouWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnYouWonPropertyChanged();
        }

        private void OnYouWonPropertyChanged()
        {
            if (YouWon == true)
            {
                PopMessage youWonMessage = new PopMessage("You Won", "Keep playing", "Return to main menu");
                if (youWonMessage.ShowDialog() != true)
                {
                    if (youWonMessage.Choose == true) 
                    {
                        BackToMainMenu();
                    }
                }
            }
            YouWon = false;
        }

        public bool OpponentWon
        {
            get { return (bool)GetValue(OpponentWonProperty); }
            set { SetValue(OpponentWonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YouWon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpponentWonProperty =
            DependencyProperty.Register("YouWon", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnOpponentWonPropertyChanged));

        private static void OnOpponentWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnOpponentWonPropertyChanged();
        }

        private void OnOpponentWonPropertyChanged()
        {
            if (OpponentWon == true)
            {
                MessageBox.Show("You Lose!!!");
            }
            OpponentWon = false;
        }


        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            PopMessage exitMessage = new PopMessage("Do you want to exit this maze?", "No", "Yes");
            if (exitMessage.ShowDialog() != true)
            {
                if (exitMessage.Choose == true) //exit the game
                {
                    BackToMainMenu();
                }
            }
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

        private void BackToMainMenu()
        {
            vm.Close();
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }

    }
}
