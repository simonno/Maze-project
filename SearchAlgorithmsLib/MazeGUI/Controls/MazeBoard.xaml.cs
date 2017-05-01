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



        public int InitialPos
        {
            get { return (int)GetValue(InitialPosProperty); }
            set { SetValue(InitialPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));



        public int GoalPos
        {
            get { return (int)GetValue(GoalPosProperty); }
            set { SetValue(GoalPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalPosProperty =
            DependencyProperty.Register("GoalPos", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));



        //public string PlayerImageFile
        //{
        //    get { return (string)GetValue(PlayerImageFileProperty); }
        //    set { SetValue(PlayerImageFileProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PlayerImageFile.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PlayerImageFileProperty =
        //    DependencyProperty.Register("PlayerImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata(0));




        //public string ExitImageFile
        //{
        //    get { return (string)GetValue(ExitImageFileProperty); }
        //    set { SetValue(ExitImageFileProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ExitImageFile.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ExitImageFileProperty =
        //    DependencyProperty.Register("ExitImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata(0));

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
                double height  = myCanvas.Height / rows;
                
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
    }
}
