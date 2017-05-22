using MazeLib;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayerDetails.xaml
    /// </summary>
    public partial class MultiPlayerDetails : Window
    {
        private MultiPlayerDetailsViewModel vm;
        public MultiPlayerDetails()
        {
            InitializeComponent();
            vm = new MultiPlayerDetailsViewModel(new ApplicationMultiPlayerModel());
            DataContext = vm;
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (GamesList.SelectedIndex <0)
            {
                MessageBox.Show("Please choose a name for the list");
                return;
            }
            string selectedName =(string) GamesList.SelectedValue;
            Maze start = vm.Join(selectedName);

            MultiPlayer win = new MultiPlayer()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string name = MazeDetails.txtBoxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please insert a name for the maze");
                return;
            }

            string rowsText = MazeDetails.txtBoxRows.Text;
            if (string.IsNullOrEmpty(rowsText))
            {
                MessageBox.Show("Please insert the number of the maze's rows.");
                return;
            }

            string columns = MazeDetails.txtBoxColumns.Text;
            if (string.IsNullOrEmpty(columns))
            {
                MessageBox.Show("Please insert the number of the maze's columns.");
                return;
            }
            if (!int.TryParse(rowsText, out int rows))
            {
                throw new Exception("rows convert failed.");
            }

            if (!int.TryParse(columns, out int cols))
            {
                throw new Exception("cols convert failed.");
            }

            string start = vm.Start(name,rows, cols);
        }
    }
}
