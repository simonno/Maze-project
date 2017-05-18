using System;
using System.Collections.Generic;
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

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayerDetails.xaml
    /// </summary>
    public partial class SinglePlayerDetails : Window
    {
        public SinglePlayerDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
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

            SinglePlayer win = new SinglePlayer(name, rows, cols)
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            this.Close();
        }
    }
}
