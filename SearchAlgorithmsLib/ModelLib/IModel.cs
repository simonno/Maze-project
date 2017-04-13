using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public interface IModel
    {
        Maze GenerateMaze(String name, int rows,  int cols);
    }
}
