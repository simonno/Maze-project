using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    class MultiPlayerViewModel : NotifyChanged
    {

        private IMultiPlayerModel model;
        private Position playerPos;

        public MultiPlayerViewModel(IMultiPlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "PlayerPos")
                {
                    PlayerPos = model.PlayerPos;
                } else if (e.PropertyName == "OpponentPos")
                {
                    OpponentPos = model.OpponentPos;
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

        public Position OpponentPos
        {
            get
            {
                return playerPos;
            }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("OpponentPos");
            }
        }

        public void Play(Direction move)
        {
            model.MovePlayer(move);
        }
     

        public void Close()
        {
            model.Close(MazeName);
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
        }
        public int MazeCols
        {
            get
            {
                return model.MazeCols;
            }
        }
        public void MovePlayer(Direction d)
        {
            model.MovePlayer(d);
        }

    }
}
