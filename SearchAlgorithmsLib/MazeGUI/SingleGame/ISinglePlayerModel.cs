using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Drawing;

namespace MazeGUI.SingleGame
{
    public interface ISinglePlayerModel : INotifyPropertyChanged
    {
        string MazeToString { get; }
        string MazeName { get; }
        int MazeRows { get; }
        int MazeCols { get; }
         Point PlayerPos { get; }

            MazeSolution Solve();
        void ChangePlayerPos(Direction d);
    }
}
