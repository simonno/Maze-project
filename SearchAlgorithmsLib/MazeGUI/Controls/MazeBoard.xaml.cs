using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        public MazeBoard()
        {
            InitializeComponent();
        }



        public string ExitImageFile
        {
            get { return (string)GetValue(ExitImageFileProperty); }
            set { SetValue(ExitImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitImageFileProperty =
            DependencyProperty.Register("ExitImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("" +
                "\\Images\\exit1.png"));


        public string PlayerImageFile
        {
            get { return (string)GetValue(PlayerImageFileProperty); }
            set { SetValue(PlayerImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerImageFileProperty =
            DependencyProperty.Register("PlayerImageFile", typeof(string),
                typeof(MazeBoard), new PropertyMetadata(""+
                    "\\Images\\simpson.png"));



        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty = 
            DependencyProperty.Register("Rows", typeof(int), typeof(MazeBoard), new PropertyMetadata(Properties.Settings.Default.MazeRows));



        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("Cols", typeof(int), typeof(MazeBoard), new PropertyMetadata(Properties.Settings.Default.MazeCols));




        public string Maze
        {
            get { return (string)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyPropertyMaze.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard), new PropertyMetadata("1",OnMazePropertyChanged));


        private static void OnMazePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnMazePropertyChanged();
        }
        private void OnMazePropertyChanged()
        {
            string s = Maze;
            int rows = Rows;
            int cols = Cols;
            double width = myCanvas.Width / cols;
            double height = myCanvas.Height / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Label l = new Label();
                    char c = s[i + rows * j];
                    l.Content = c;
                    l.Width = width;
                    l.Height = height;
                    Canvas.SetLeft(l, width * i);
                    Canvas.SetTop(l, height * j);
                    switch (c)
                    {
                        case '1':
                            l.Background = Brushes.Black;
                            break;

                        case '0':
                            l.Background = Brushes.White;
                            break;

                        case '*':
                            //ul.Background = Brushes.Red;  

                            string path = System.IO.Directory.GetCurrentDirectory();
                            DirectoryInfo father = System.IO.Directory.GetParent(path);
                            DirectoryInfo father2 = System.IO.Directory.GetParent(father.ToString());
                            string fullPath = father2 + PlayerImageFile;
                            l.Background = new ImageBrush(new BitmapImage(
                                new Uri(fullPath)));
                            break;

                        case '#':
                            //l.Background = Brushes.Green;
                            string pathExit = System.IO.Directory.GetCurrentDirectory();
                            
                            DirectoryInfo fatherExit = System.IO.Directory.GetParent(pathExit);
                            DirectoryInfo fatherExit2 = System.IO.Directory.GetParent(fatherExit.ToString());
                            string fullPathExit = fatherExit2 + ExitImageFile;
                            l.Background = new ImageBrush(new BitmapImage(new Uri(fullPathExit)));
                           break;

                    }
                    l.Foreground = Brushes.Red;
                    myCanvas.Children.Add(l);
                }
            }
        }
    }
}
