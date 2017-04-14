using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public interface IModel 
    {
        Maze GenerateMaze(string name, int rows, int cols);

        MazeSolution Solve(string name, int typeOfSolve);

        void Start(string name, int rows, int cols);

        List<string> List();

        void Join(string name);

        void Close(string name);

    }
}
