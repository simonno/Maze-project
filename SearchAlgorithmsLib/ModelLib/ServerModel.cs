using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using SearchAlgorithmsLib;

namespace ModelLib
{
    class ServerModel : IModel
    {
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, Maze> multiPlayerWaiting;
        private Dictionary<string, Maze> multiPlayerOnline;
        private Dictionary<string, MazeSolution> mazesSolutions;

        public ServerModel()
        {
            mazes = new Dictionary<string, Maze>();
            multiPlayerWaiting = new Dictionary<string, Maze>();
            multiPlayerOnline = new Dictionary<string, Maze>();
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

        public Maze Join(string name) 
        {
            if(!multiPlayerWaiting.ContainsKey(name))
            {
                throw new Exception("This maze does not exist - " + name);
            }
            Maze maze =  multiPlayerWaiting[name];
            multiPlayerOnline[name] = maze;
            multiPlayerWaiting.Remove(name);
            return maze;
        }

        public List<string> List()
        {
            Dictionary<string, Maze>.KeyCollection namesCollaction =  multiPlayerWaiting.Keys;
            string[] temp = new string[namesCollaction.Count];
            namesCollaction.CopyTo(temp, 0);
            return new List<string>(temp);
        }

        public MazeSolution Solve(string name, int typeOfSolve)
        {
            if (mazesSolutions.ContainsKey(name))
            {
                return mazesSolutions[name];
            }

            if (mazes.ContainsKey(name))
            {
                Maze maze = mazes[name];
                MazeSolution s = Solve(maze, typeOfSolve);
                mazesSolutions.Add(name, s);
                return s;
            }

            if (multiPlayerWaiting.ContainsKey(name))
            {
                Maze maze = multiPlayerWaiting[name];
                MazeSolution s = Solve(maze, typeOfSolve);
                mazesSolutions.Add(name, s);
                return s;
            }

            throw new Exception("This maze does not exist - " + name);
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
            multiPlayerWaiting.Add(name, maze);
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

        public bool IsPair(string name)
        {
            return multiPlayerOnline.ContainsKey(name);
        }

        public Maze GetMaze(string name)
        {
            if (multiPlayerWaiting.ContainsKey(name))
            {
                return multiPlayerWaiting[name];
            }

            if (mazes.ContainsKey(name))
            {
                return mazes[name];
            }
            throw new Exception("This maze does not exist - " + name);
        }
    }
}
