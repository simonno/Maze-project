using MazeGUI.MultiGame;
using MazeGUI.SingleGame;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerDetails win = new SinglePlayerDetails()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }

//vvb
        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerDetails win = new MultiPlayerDetails()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Settings win = new Settings.Settings()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }
    }
}
