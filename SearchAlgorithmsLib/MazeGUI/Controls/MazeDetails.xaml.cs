using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for MazeDetails.xaml
    /// </summary>
    public partial class MazeDetails : UserControl
    {
        public MazeDetails()
        {
            InitializeComponent();
        }

        private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    tb.Clear();
                }
            }
        }
    }
}
