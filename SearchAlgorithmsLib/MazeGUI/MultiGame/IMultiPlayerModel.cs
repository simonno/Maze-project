using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    interface IMultiPlayerModel
    {
        void Start(string mazeName, int rows, int cols);
        List<string> GamesList
        {
            get;
        }
        void Join(string mazeName);
    }
}
