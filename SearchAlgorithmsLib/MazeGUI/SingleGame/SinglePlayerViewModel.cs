using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.SingleGame
{
    public class SinglePlayerViewModel : ViewModel
    {
        private ISinglePlayerModel model;

        public SinglePlayerViewModel(ISinglePlayerModel model)
        {
            this.model = model;
        }

        public string MazeToString
        {
            get
            {
                string maze = model.MazeToString;
                return maze.Replace(Environment.NewLine, "");
            }

            set
            {
                NotifyPropertyChanged("MazeToString");
            }
        }

        public string MazeName
        {
            get
            {
                return model.MazeName;
            }

            set
            {
                NotifyPropertyChanged("MazeName");
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

            set
            {
                NotifyPropertyChanged("MazeCols");
            }
        }
        public string Solve
        {
            get
            {
                MazeSolution mazeSolve = model.Solve();
                return mazeSolve.SolutionString;
            }
            set
            {
                NotifyPropertyChanged("MazeSolve");
            }
        }
        public string s()
        {
            
            MazeSolution mazeSolve = model.Solve();
            return mazeSolve.SolutionString;
            
        }
     
    }
}
