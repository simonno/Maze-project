using System;
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




        public int DefaultMazeCols
        {
            get { return (int)GetValue(DefaultMazeColsProperty); }
            set { SetValue(DefaultMazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultMazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultMazeColsProperty =
            DependencyProperty.Register("DefaultMazeCols", typeof(int), typeof(MazeDetails), new PropertyMetadata(0, OnDefaultMazeColsChanged));

        private static void OnDefaultMazeColsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MazeDetails mazeDetails)
            {
                mazeDetails.OnDefaultMazeColsChanged();
            }
        }

        private void OnDefaultMazeColsChanged()
        {
            txtBoxColumns.Text = DefaultMazeCols.ToString();
        }

        public int DefaultMazeRows
        {
            get { return (int)GetValue(DefaultMazeRowsProperty); }
            set { SetValue(DefaultMazeRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultMazeRowsProperty =
            DependencyProperty.Register("DefaultMazeRows", typeof(int), typeof(MazeDetails), new PropertyMetadata(0, OnDefaultMazeRowsChanged));

        private static void OnDefaultMazeRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MazeDetails mazeDetails)
            {
                mazeDetails.OnDefaultMazeRowsChanged();
            }
        }

        private void OnDefaultMazeRowsChanged()
        {
            txtBoxRows.Text = DefaultMazeRows.ToString();
        }
    }
}
