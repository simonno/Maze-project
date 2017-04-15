using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace ModelLib
{
    class ServerModel : IModel
    {
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, Maze> multiPlayerMazes;
        private Dictionary<string, MazeSolution> mazesSolutions;

        public ServerModel()
        {
            mazes = new Dictionary<string, Maze>();
            multiPlayerMazes = new Dictionary<string, Maze>();
            mazesSolutions = new Dictionary<string, MazeSolution>();
        }


        public void Close(string name)
        {
            throw new NotImplementedException();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = Generate(name, rows, cols);
            mazes.Add(name, maze);
            return maze;
        }

        public void Join(string name) 
        {
            if(!multiPlayerMazes.ContainsKey(name))
            {
                throw new Exception("This maze does not exist - " + name);
            }


        }

        public List<string> List()
        {
            Dictionary<string, Maze>.KeyCollection namesCollaction =  multiPlayerMazes.Keys;
            string[] temp = new string[namesCollaction.Count];
            namesCollaction.CopyTo(temp, 0);
            return new List<string>(temp);
        }

        public MazeSolution Solve(string name, int typeOfSolve)
        {
            if (!mazes.ContainsKey(name))
            {
                throw new Exception("This maze does not exist - " + name);
            }

            if (mazesSolutions.ContainsKey(name))
            {
                return mazesSolutions[name];
            }

            Maze maze = mazes[name];
            MazeSolution s =  Solve(maze, typeOfSolve);
            mazesSolutions.Add(name, s);
            return s;
        }

        private Maze Generate(string name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }

        public void Start(string name, int rows, int cols)
        {
            Maze maze = Generate(name, rows, cols);
            multiPlayerMazes.Add(name, maze);
            
        }

        private MazeSolution Solve(Maze maze, int type)
        {
            ObjectAdapter adapter = new ObjectAdapter(maze);

            BFS<Position, int> bfs = new BFS<Position, int>();
            DFS<Position, int> dfs = new DFS<Position, int>();
            switch (type)
            {
                case 0:
                    return ConvertSolution(bfs.Search(adapter));
                case 1:
                    return ConvertSolution(dfs.Search(adapter));
                default:
                    throw new Exception("This search type does not exist - " + type);
            }
        }

        private MazeSolution ConvertSolution(Solution<Position, int> s)
        {
            List<Position> positionList = new List<Position>();
            foreach (State<Position, int> state in s.GetSolution())
            {
                positionList.Add(state.StateValue);
            }

            return new MazeSolution(s.GetEvaluatedNodes(), positionList);
        }
    }
}
