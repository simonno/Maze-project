using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    class MultiPlayerDetailsViewModel : ViewModel
    {
        private IMultiPlayerDetailsModel model;

        public MultiPlayerDetailsViewModel(IMultiPlayerDetailsModel model)
        {
            this.model = model;
        }
        public ObservableCollection<string> GamesList
        {

            get
            {
                List<string> games = model.List();
                return new ObservableCollection<string>(games);
            }

            set
            {
                NotifyPropertyChanged("GamesList");
            }

        }

        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set
            {
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set
            {
                NotifyPropertyChanged("MazeCols");
            }
        }
        public string Start(string mazeName, int rows, int cols)
        {

            Maze maze = model.Start( mazeName, rows,  cols);
            return maze.ToJSON();
        }
    }
}
