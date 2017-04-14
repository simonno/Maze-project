using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace MazeAdaptorApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.CompareSolvers(2000, 2000);
        }

         public void CompareSolvers(int rows  ,int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            Console.WriteLine(maze.ToString());
            ObjectAdapter adapter = new ObjectAdapter(maze);

            BFS<Position, int> bfs = new BFS<Position, int>();
            DFS<Position, int> dfs = new DFS<Position, int>();
            dfs.Search(adapter);
            Console.WriteLine("DFS:" + dfs.getNumberOfNodesEvaluated());

            bfs.Search(adapter);
            Console.WriteLine("BFS:" + bfs.getNumberOfNodesEvaluated());
            return;
        }
    }
}
