using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using SearchAlgorithmsLib;
using System.Net.Sockets;
using ClientLib;

namespace ModelLib
{
    public class ServerModel : IModel
    {
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, MultiPlayerInfo> multiPlayerWaiting;
        private Dictionary<string, MultiPlayerInfo> multiPlayerOnline;
        private Dictionary<string, MazeSolution> mazesSolutions;

        public ServerModel()
        {
            mazes = new Dictionary<string, Maze>();
            multiPlayerWaiting = new Dictionary<string, MultiPlayerInfo>();
            multiPlayerOnline = new Dictionary<string, MultiPlayerInfo>();
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

        public Maze Join(string name, ClientOfServer guest)
        {
            if (!multiPlayerWaiting.ContainsKey(name))
            {
                throw new Exception("This maze does not exist - " + name);
            }
            MultiPlayerInfo mp = multiPlayerWaiting[name];
            mp.Guest = guest;
            multiPlayerOnline[name] = mp;
            multiPlayerWaiting.Remove(name);
            return mp.Maze;
        }

        public List<string> List()
        {
            Dictionary<string, MultiPlayerInfo>.KeyCollection namesCollaction = multiPlayerWaiting.Keys;
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

            //if (multiPlayerWaiting.ContainsKey(name))
            //{
            //    Maze maze = multiPlayerWaiting[name];
            //    MazeSolution s = Solve(maze, typeOfSolve);
            //    mazesSolutions.Add(name, s);
            //    return s;
            //}

            throw new Exception("This maze does not exist - " + name);
        }

        private Maze Generate(string name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }

        public void Start(string name, int rows, int cols, ClientOfServer host)
        {
            Maze maze = Generate(name, rows, cols);
            MultiPlayerInfo mp = new MultiPlayerInfo()
            {
                Host = host,
                Maze = maze
            };
            multiPlayerWaiting.Add(name, mp);
        }

        private MazeSolution Solve(Maze maze, int type)
        {
            ObjectAdapter adapter = new ObjectAdapter(maze);

            BFS<Position, int> bfs = new BFS<Position, int>();
            DFS<Position, int> dfs = new DFS<Position, int>();
            switch (type)
            {
                case 0:
                    return ConvertSolution(bfs.Search(adapter), maze.Name);
                case 1:
                    return ConvertSolution(dfs.Search(adapter), maze.Name);
                default:
                    throw new Exception("This search type does not exist - " + type);
            }
        }

        private MazeSolution ConvertSolution(Solution<Position, int> s, string name)
        {
            List<Position> positionList = new List<Position>();
            foreach (State<Position, int> state in s.GetSolution())
            {
                positionList.Add(state.StateValue);
            }

            MazeSolution ms = new MazeSolution()
            {
                EvaluatedNodes = s.GetEvaluatedNodes(),
                Solution = positionList,
                GameName = name
            };
            return ms;

        }

        public bool IsPair(string name)
        {
            return multiPlayerOnline.ContainsKey(name);
        }

        public Maze GetMaze(string name)
        {
            if (multiPlayerWaiting.ContainsKey(name))
            {
                return multiPlayerWaiting[name].Maze;
            }

            if (mazes.ContainsKey(name))
            {
                return mazes[name];
            }
            throw new Exception("This maze does not exist - " + name);
        }

        public Tuple<ClientOfServer, PlayerDirection> Play(string move, ClientOfServer player)
        {
            MultiPlayerInfo mp = FindMPInfo(player);
            ClientOfServer otherPlayer = mp.GetTheOtherPlayer(player);
            PlayerDirection pd = new PlayerDirection()
            {
                GameName = mp.Maze.Name,
                Move = move
            };
            return new Tuple<ClientOfServer, PlayerDirection>(otherPlayer, pd);
        }

        public ClientOfServer Close(ClientOfServer player)
        {
            return FindMPInfo(player).GetTheOtherPlayer(player);

        }

        private MultiPlayerInfo FindMPInfo(ClientOfServer player)
        {
            foreach (MultiPlayerInfo mp in multiPlayerOnline.Values)
            {
                if (mp.ContainPlayer(player))
                {
                    return mp;
                }
            }
            throw new Exception("This player does not exist.");
        }
    }
}
