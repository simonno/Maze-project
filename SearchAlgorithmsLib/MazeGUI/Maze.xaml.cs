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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for Maze.xaml
    /// </summary>
    public partial class Maze : UserControl
    {
        List<List<Label>> mazeCells;
        public Maze(int rows, int columns)
        {
            InitializeComponent();
            mazeCells = new List<List<Label>>(rows);
            for (int i = 0; i < rows; i++)
            {
                mazeCells[i] = new List<Label>(columns);
            }
            mazeCells[2] = l3;
            mazeCells[3] = l4;
            mazeCells[4] = l5;
            mazeCells[5] = l6;
            mazeCells[6] = l7;
            mazeCells[7] = l8;
            mazeCells[8] = l9;
        }
    }
}
