using ClientLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);

        MazeSolution Solve(string name, int typeOfSolve);

        void Start(string name, int rows, int cols, ClientOfServer host);

        List<string> List();

        Maze Join(string name, ClientOfServer guest);

        Tuple<ClientOfServer, PlayerDirection> Play(string move, ClientOfServer player);

        ClientOfServer Close(ClientOfServer player);

        void Close(string name);

        bool IsPair(string name);

        Maze GetMaze(string name);

    }
}
