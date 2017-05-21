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

        public ObservableCollection<string> GamesList
        {

            get
            {
                List<string> games = new List<string>
                {
                    "noam",
                    "n6878",
                    "n123",
                    "noa"
                };
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

    }
}
