using System;
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
        private string boardDescription;

        public MazeBoard()
        {
            boardDescription = "";
            InitializeComponent();
            double width = myCanvas.Width / Cols;
            double height = myCanvas.Height / Rows;
            //CharacterImg.Source = new BitmapImage(new Uri(PlayerImageFile));
            //ExitImg.Source = new BitmapImage(new Uri(ExitImageFile));
           // Canvas.SetLeft(CharacterImg, )
        }

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));




        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("Cols", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));



        public string InitialPos
        {
            get
            {
                Point init = (Point)GetValue(InitialPosProperty);
                return init.ToString();
            }
            set
            {
                string[] args = value.Split(',');
                int x = int.Parse(args[0]);
                int y = int.Parse(args[1]);
                SetValue(InitialPosProperty, new Point(x, y));
            }
        }

        // Using a DependencyProperty as the backing store for InitialPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(Point), typeof(MazeBoard), new PropertyMetadata(new Point(0, 0)));



        public Point GoalPos
        {
            get
            {
                // Point init = 
                return (Point)GetValue(GoalPosProperty);
            }
            set
            {
                //string[] args = value.Split(',');
                //int x = int.Parse(args[0]);
                //int y = int.Parse(args[1]);
                SetValue(GoalPosProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for GoalPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalPosProperty =
            DependencyProperty.Register("GoalPos", typeof(Point), typeof(MazeBoard), new PropertyMetadata(new Point(0, 0)));



        public string PlayerImageFile
        {
            get { return (string)GetValue(PlayerImageFileProperty); }
            set { SetValue(PlayerImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerImageFileProperty =
            DependencyProperty.Register("PlayerImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("../Images/simpson.png"));




        public string ExitImageFile
        {
            get { return (string)GetValue(ExitImageFileProperty); }
            set { SetValue(ExitImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitImageFileProperty =
            DependencyProperty.Register("ExitImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("../Images/exit1.png"));

        public string Maze
        {
            get
            {
                return boardDescription;
            }
            set
            {

                string s = value;
                boardDescription = value;
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

                        if (c == '1')
                        {
                            l.Foreground = Brushes.Red;
                            l.Background = Brushes.Black;

                        }
                        else if (c == '0')
                        {
                            l.Foreground = Brushes.Red;
                            l.Background = Brushes.White;
                        }
                        myCanvas.Children.Add(l);
                    }
                }
            }

        }
        public class Point
        {
            int x;
            int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Point(string args)
            {
                string[] args2 = args.Split(',');
                x = int.Parse(args2[0]);
                y = int.Parse(args2[1]);
            }

            public override string ToString()
            {
                return x.ToString() + "," + y.ToString();
            }

        }

    }
}
