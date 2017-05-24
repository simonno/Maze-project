using MazeLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MazeGUI.SingleGame
{
    public class SinglePlayerViewModel : NotifyChanged
    {
        private ISinglePlayerModel model;
        private Point playerPos;

        public SinglePlayerViewModel(ISinglePlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "PlayerPos")
                {
                   MazeToString
                }
            };
        }

        public string MazeToString
        {
            get
            {
                string maze = model.MazeToString;
                return maze.Replace(Environment.NewLine, "");
            }
        }

        public string MazeName
        {
            get
            {
                return model.MazeName;
            }
        }

        public int MazeRows
        {
            get
            {
                return model.MazeRows;
            }

            set
            {
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get
            {
                return model.MazeCols;
            }
        }
        public string Solve
        {
            get
            {
                MazeSolution mazeSolve = model.Solve();
                return mazeSolve.SolutionString;
            }
        }
        public string s()
        {

            MazeSolution mazeSolve = model.Solve();
            return mazeSolve.SolutionString;

        }
        public void movePlayer(Direction d)
        {

            switch (d)
            {
                case Direction.Left:
                    playerPos = new Point(playerPos.X - 1, playerPos.Y);
                    break;
                case Direction.Right:
                    playerPos = new Point(playerPos.X + 1, playerPos.Y);
                    break;
                case Direction.Up:
                    playerPos = new Point(playerPos.X, playerPos.Y - 1);
                    break;
                case Direction.Down:
                    playerPos = new Point(playerPos.X, playerPos.Y + 1);
                    break;
            }
            Point p = playerPos;
            if (model.Valid(p))
            {

            }
        }
        
}
