using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.SingleGame
{
    public interface ISinglePlayerModel
    {
        string MazeToString { get; }
        string MazeName { get; }
        int MazeRows { get; }
        int MazeCols { get; }
    
        MazeSolution Solve();

    }
}
