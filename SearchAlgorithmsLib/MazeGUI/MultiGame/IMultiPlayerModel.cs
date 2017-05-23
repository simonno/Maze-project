using System.Collections.Generic;
using System.ComponentModel;

namespace MazeGUI.MultiGame
{
    public interface IMultiPlayerModel : INotifyPropertyChanged
    {
        void Start(string mazeName, int rows, int cols);

        void Join(string mazeName);

        List<string> GamesList { get; }

        string MazeToString { get; }
        string MazeName { get; }
        int MazeRows { get; }
        int MazeCols { get; }
    }
}
