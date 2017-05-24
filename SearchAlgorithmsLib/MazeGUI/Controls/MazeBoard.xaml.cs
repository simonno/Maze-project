using MazeLib;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        private List<List<int>> mazeCells;
        private Label player;
       private Point playerPos;
        private Point exitPos;

        public MazeBoard()
        {
            player = new Label();
            InitializeComponent();
        }

        public void MoveBackToTheStart()
        {
            PlayerPos = PlayerStartPoint;
        }
        public void MoveUp()
        {
            PlayerPos = new Point(PlayerPos.X, PlayerPos.Y - 1);
        }
        public void MoveDown()
        {
            PlayerPos = new Point(PlayerPos.X, PlayerPos.Y + 1);

        }
        public void MoveLeft()
        {
            PlayerPos = new Point(PlayerPos.X - 1, PlayerPos.Y);

        }
        public void MoveRight()
        {
            PlayerPos = new Point(PlayerPos.X + 1, PlayerPos.Y);
        }

        public Point PlayerPos
        {
            get { return (Point)GetValue(PlayerPosProperty); }
            set { SetValue(PlayerPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerPosProperty =
            DependencyProperty.Register("PlayerPos", typeof(Point), typeof(MazeBoard), new PropertyMetadata(new Point(0,0), OnPlayerPosPropertyChanged));

        private static void OnPlayerPosPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnPlayerPosPropertyChanged();
        }

        private void OnPlayerPosPropertyChanged()
        {
            Point p = PlayerPos;
            if (Valid(p))
            {
                double width = myCanvas.Width / Cols;
                double height = myCanvas.Height / Rows;
                //MoveTo(player, new Point(width * p.X, height * p.Y));
                Canvas.SetTop(player, height * p.Y);
                Canvas.SetLeft(player, width * p.X);
            }
            //else
            //{
            //    MessageBox.Show("cant go there");
            //}
            if ((PlayerPos.X == exitPos.X) && (PlayerPos.Y == exitPos.Y))
            {
                MessageBox.Show("you win!!");
            }
        }

        //public Point PlayerPos
        //{
        //    get
        //    {
        //        return playerPos;
        //    }
        //    set
        //    {
        //        Point p = value;
        //        if (Valid(p))
        //        {
        //            double width = myCanvas.Width / Cols;
        //            double height = myCanvas.Height / Rows;
        //            playerPos = p;
        //            MoveTo(player, new Point(width * p.X, height * p.Y));
        //        }
        //        //else
        //        //{
        //        //    MessageBox.Show("cant go there");
        //        //}
        //        if ((PlayerPos.X == exitPos.X) && (PlayerPos.Y == exitPos.Y))
        //        {
        //            MessageBox.Show("you win!!");
        //        }
        //    }
        //}
        public Point PlayerStartPoint
        {
            get; set;
        }
        private bool Valid(Point p)
        {
            if ((p.X < 0) || (p.X > Cols - 1) || (p.Y < 0) || (p.Y > Rows - 1))
            {
                return false;
            }
            int x = Convert.ToInt32(p.X);
            int y = Convert.ToInt32(p.Y);
            if (mazeCells[x][y] == 0)
                return true;
            return false;
        }

        public void MoveTo(Label target, Point newP)
        {

            Point oldP = new Point()
            {
                X = Canvas.GetLeft(target),
                Y = Canvas.GetTop(target)
            };
            DoubleAnimation anim1 = new DoubleAnimation(oldP.X, newP.X, TimeSpan.FromSeconds(0.20));
            DoubleAnimation anim2 = new DoubleAnimation(oldP.Y, newP.Y, TimeSpan.FromSeconds(0.20));

            target.BeginAnimation(Canvas.LeftProperty, anim1);
            target.BeginAnimation(Canvas.TopProperty, anim2);
            Thread.Sleep(500);
        }

        public string ExitImageFile
        {
            get { return (string)GetValue(ExitImageFileProperty); }
            set { SetValue(ExitImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitImageFileProperty =
            DependencyProperty.Register("ExitImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("exit1.png"));



        public string PlayerImageFile
        {
            get { return (string)GetValue(PlayerImageFileProperty); }
            set { SetValue(PlayerImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerImageFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerImageFileProperty =
            DependencyProperty.Register("PlayerImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("simpson.png"));



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

        public Label Player { get => player; set => player = value; }

        // Using a DependencyProperty as the backing store for MyPropertyMaze.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard), new PropertyMetadata("1", OnMazePropertyChanged));


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

            mazeCells = new List<List<int>>(cols);
            for (int xPos = 0; xPos < cols; xPos++)
            {
                mazeCells.Add(new List<int>(rows));
                for (int yPos = 0; yPos < rows; yPos++)
                {

                    Label l = new Label();
                    char c = s[xPos + cols * yPos];
                    l.Width = width;
                    l.Height = height;
                    Canvas.SetLeft(l, width * xPos);
                    Canvas.SetTop(l, height * yPos);
                    switch (c)
                    {
                        case '1':
                            l.Background = Brushes.Black;
                            mazeCells[xPos].Insert(yPos, 1);
                            break;

                        case '0':
                            l.Background = Brushes.White;
                            mazeCells[xPos].Insert(yPos, 0);
                            break;

                        case '*':
                            l.Background = Brushes.Red;
                            player.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + PlayerImageFile)));
                            player.Width = width;
                            player.Height = height;
                            Canvas.SetLeft(player, width * xPos);
                            Canvas.SetTop(player, height * yPos);
                            PlayerStartPoint = new Point(xPos, yPos);
                            mazeCells[xPos].Insert(yPos, 0);
                            break;

                        case '#':
                            //l.Background = Brushes.Green;
                            l.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + ExitImageFile)));
                            mazeCells[xPos].Insert(yPos, 0);
                            exitPos = new Point(xPos, yPos);
                            break;

                    }
                    myCanvas.Children.Add(l);
                }
            }
            PlayerPos = PlayerStartPoint;
            myCanvas.Children.Add(player);
        }



        //public class Point
        //{
        //    public Point()
        //    {
        //        X = 0;
        //        Y = 0;
        //    }
        //    public Point(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public int X
        //    {
        //        set; get;
        //    }
        //    public int Y
        //    {
        //        set; get;
        //    }
        //}
    }
}
