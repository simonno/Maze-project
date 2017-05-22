using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    interface IMultiPlayerDetailsModel
    {
        Maze Start(string mazeName, int rows, int cols);
        List<string> List();
    }
}
