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
        List<List<MazeCell>> mazeCells;

        public Maze(int rows, int columns)
        {
            InitializeComponent();

            for (int j = 0; j < columns; j++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(1, GridUnitType.Star);
                Grid.ColumnDefinitions.Add(gridCol);
            }

            for (int j = 0; j < rows; j++)
            {
                RowDefinition gridRow = new RowDefinition();
                gridRow.Height = new GridLength(1, GridUnitType.Star);
                Grid.RowDefinitions.Add(gridRow);
            }

            mazeCells = new List<List<MazeCell>>(rows);
            for (int i = 0; i < rows; i++)
            {
                ///mazeCells[i] = new List<MazeCell>(columns);
                for (int j = 0; j < columns; j++)
                {
                    MazeCell m = new MazeCell(MazeCell.Colors.White);
                    Grid.Children.Add(m);
                    Grid.SetRow(m, i);
                    Grid.SetColumn(m, j);
                }
            }
        }
    }
}
