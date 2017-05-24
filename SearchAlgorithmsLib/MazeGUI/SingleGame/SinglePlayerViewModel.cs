using MazeLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeGUI.SingleGame
{
    public class SinglePlayerViewModel : NotifyChanged
    {
        private ISinglePlayerModel model;
       // private Point playerPos;

        public SinglePlayerViewModel(ISinglePlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "PlayerPos")
                {
                    PlayerPos = model.PlayerPos;
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
        public Point PlayerPos
        {
            get
            {
                return model.PlayerPos;
            }
            set
            {
                NotifyPropertyChanged("PlayerPos");
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
            model.ChangePlayerPos(d);
        }

    }
}
