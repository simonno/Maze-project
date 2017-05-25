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
        private Position playerPos;
        private bool youWon;

        public SinglePlayerViewModel(ISinglePlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "PlayerPos")
                {
                    PlayerPos = model.PlayerPos;
                }
                else if (e.PropertyName == "YouWon")
                {
                    YouWon = model.YouWon;
                }
            };
        }

        public string MazeToString
        {
            get
            {
                string maze = model.MazeToString;
                maze = maze.Replace(Environment.NewLine, "");
                maze = maze.Replace("*", "0");
                maze = maze.Replace("#", "0");
                return maze;
            }
        }

        public bool YouWon
        {
            get { return youWon; }
            set
            {
                youWon = value;
                NotifyPropertyChanged("YouWon");
            }
        }

        public Position InitialPos
        {
            get
            {
                return model.InitialPos;
            }
        }

        public Position GoalPos
        {
            get
            {
                return model.GoalPos;
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
        public Position PlayerPos
        {
            get
            {
                return playerPos;
            }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("PlayerPos");
            }
        }
        public void Reset()
        {
            model.Reset();
        }

        public void Solve()
        {
            model.Solve();
        }

        public void MovePlayer(Direction d)
        {
            model.MovePlayer(d);
        }

    }
}
