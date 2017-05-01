using System.Windows.Controls;
using System.Windows.Media;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MazeCell.xaml
    /// </summary>
    public partial class MazeCell : UserControl
    {
        public enum Colors { White, Black };
        public MazeCell(Colors color)
        {
            switch (color)
            {
                case Colors.White:
                    Background = new SolidColorBrush(System.Windows.Media.Colors.White);
                    break;

                case Colors.Black:
                    Background = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    break;
            }
            InitializeComponent();
        }
    }
}
