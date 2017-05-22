﻿using System;
using System.Collections.Generic;
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
        private Point playerStartPoint;
        private Point exitPos;

        public MazeBoard()
        {
            player = new Label();
            InitializeComponent();
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
            get
            {
                return playerPos;
            }
            set
            {
                Point p = value;
                if (Valid(p))
                {
                    double width = myCanvas.Width / Cols;
                    double height = myCanvas.Height / Rows;
                    playerPos = p;
                    MoveTo(player, new Point(width * p.X, height * p.Y));
                    //int rows = Rows;
                    //int cols = Cols;
                   
                    //Canvas.SetLeft(player, width * p.X);
                    //Canvas.SetTop(player, height * p.Y);
                }
                else
                {
                    MessageBox.Show("cant go there");

                }
                if ((PlayerPos.X == exitPos.X) && (PlayerPos.Y == exitPos.Y))
                {
                    MessageBox.Show("you win!!");
                }
            }
        }
        public Point PlayerStartPoint
        {
            get
            {
                return playerStartPoint;
            }
        }
        private bool Valid(Point p)
        {
            if ((p.X < 0) || (p.X > mazeCells.Capacity-1) || (p.Y < 0) || (p.Y > mazeCells.Capacity-1))
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
            DoubleAnimation anim1 = new DoubleAnimation(oldP.X, newP.X, TimeSpan.FromSeconds(0.25));
            DoubleAnimation anim2 = new DoubleAnimation(oldP.Y, newP.Y, TimeSpan.FromSeconds(0.25));

            target.BeginAnimation(Canvas.LeftProperty, anim1);
            target.BeginAnimation(Canvas.TopProperty, anim2);
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


            mazeCells = new List<List<int>>(rows);
            for (int i = 0; i < rows; i++)
            {
               mazeCells.Add(new List<int>(cols));
                for (int j = 0; j < cols; j++)
                {
                    Label l = new Label();
                    char c = s[i + rows * j];
                    l.Width = width;
                    l.Height = height;
                    Canvas.SetLeft(l, width * i);
                    Canvas.SetTop(l, height * j);
                    switch (c)
                    {
                        case '1':
                            l.Background = Brushes.Black;
                            mazeCells[i].Insert(j , 1);
                            break;

                        case '0':
                            l.Background = Brushes.White;
                            mazeCells[i].Insert(j, 0);
                            break;

                        case '*':
                            l.Background = Brushes.Red;
                            player.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + PlayerImageFile)));
                            player.Width = width;
                            player.Height = height;
                            Canvas.SetLeft(player, width * i);
                            Canvas.SetTop(player, height * j);
                            playerPos = new Point(i, j);
                            playerStartPoint = new Point(i, j);
                            mazeCells[i].Insert(j, 0);
                            break;

                        case '#':
                            //l.Background = Brushes.Green;
                            l.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + ExitImageFile)));
                            mazeCells[i].Insert(j, 0);
                            exitPos = new Point(i, j);
                            break;

                    }
                    myCanvas.Children.Add(l);
                }
            }
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
