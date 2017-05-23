using MazeLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace MazeGUI.MultiGame
{
    public interface IMultiPlayerModel : INotifyPropertyChanged
    {
        void Start(string mazeName, int rows, int cols);

        void Join(string mazeName);

        void Play(Direction d);

        List<string> GamesList { get; }

        string MazeToString { get; }
        string MazeName { get; }
        int MazeRows { get; }
        int MazeCols { get; }
        Direction OpponentPosChanged { get; }
    }
}
