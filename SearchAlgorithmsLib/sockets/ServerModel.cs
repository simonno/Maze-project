using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeGeneratorLib;
using MazeLib;



namespace ServerProject
{
    class ServerModel: IModel
    {
        private Dictionary<string, string> mazesNameAndSolution;// save name and solution
        public ServerModel()
        {
            mazesNameAndSolution = new Dictionary<string, string>;
        }
        string GenerateMaze(String name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            string answer= maze.ToJson();
            return answer;
        }

        string SolveMaze(String name, int algorithm)
        {
            string answer = null;
            if (!mazesNameAndSolution.ContainsKey(name))
            {
                ObjectAdapter adapter = new ObjectAdapter(maze);
                if (algorithm == 0)//BFS
                {
                    BFS<Position, int> bfs = new BFS<Position, int>();
                    bfs.Search(adapter);
                    answer = bfs.getNumberOfNodesEvaluated();
                }
                else if (algorithm == 1)
                {
                    DFS<Position, int> dfs = new DFS<Position, int>();
                    dfs.Search(adapter);
                    answer = dfs.getNumberOfNodesEvaluated();
                }
                mazesNameAndSolution.Add(name, answer);
            }
            else
            {
                answer = mazesNameAndSolution[name];
            }
            return answer; 
        }
    }
}
