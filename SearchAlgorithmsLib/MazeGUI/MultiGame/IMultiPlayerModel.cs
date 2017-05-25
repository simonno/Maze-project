using MazeLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    public interface IMultiPlayerModel : INotifyPropertyChanged
    {
        void Start(string mazeName, int rows, int cols);
        void Join(string mazeName);
        void Close(string mazeName);
        void MovePlayer(Direction d);
        Position PlayerPos { get; }
        Position OpponentPos { get; }
        Position InitialPos { get; }
        Position GoalPos { get; }
        List<string> GamesList { get; }
        string MazeToString { get; }
        string MazeName { get; }
        int MazeRows { get; }
        int MazeCols { get; }
        bool ExitGame { get; }
        bool LostConnection { get; }
        bool OpponentWon { get; }
        bool YouWon { get; }
    }
}
