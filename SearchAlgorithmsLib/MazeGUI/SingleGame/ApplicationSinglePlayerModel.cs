using MazeLib;
using System;
using System.Net;
using System.Threading.Tasks;
using ModelLib;
using System.Threading;

namespace MazeGUI.SingleGame
{
    public class ApplicationSinglePlayerModel : Model, ISinglePlayerModel
    {
        private int defaultSearchAlgorithm;

        public ApplicationSinglePlayerModel(string mazeName, int rows, int cols)
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
            defaultSearchAlgorithm = Properties.Settings.Default.SearchAlgorithm;
            GenerateMaze(mazeName, rows, cols);
        }

        private void GenerateMaze(string mazeName, int rows, int cols)
        {
            Connect();
            Writer.Flush();
            Writer.WriteLine("generate {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();
            string answer = Reader.ReadLine();
            Disconnect();
            answer = answer.Replace("@", Environment.NewLine);
            Maze = Maze.FromJSON(answer);
            PlayerPos = Maze.InitialPos;
            CreateMazeCells(MazeToString);
        }


        public void Solve()
        {
            Connect();
            Writer.WriteLine("solve {0} {1}", maze.Name, defaultSearchAlgorithm);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            Disconnect();
            MazeSolution ms = MazeSolution.FromJSON(answer);
            RunSolveTask(ms.SolutionString);
        }

        private void RunSolveTask(string solutionString)
        {
            Reset();
            new Task(() =>
            {
                foreach (char direction in solutionString)
                {
                    switch (direction)
                    {
                        case 'U':
                            PlayerPos = new Position(PlayerPos.Row - 1, PlayerPos.Col);
                            break;

                        case 'D':
                            PlayerPos = new Position(PlayerPos.Row + 1, PlayerPos.Col);
                            break;

                        case 'R':
                            PlayerPos = new Position(PlayerPos.Row, PlayerPos.Col + 1);
                            break;

                        case 'L':
                            PlayerPos = new Position(PlayerPos.Row, PlayerPos.Col - 1);
                            break;

                        default:
                            return;
                    }
                    Thread.Sleep(120);
                }
            }).Start();
        }

        public void Reset()
        {
            PlayerPos = Maze.InitialPos;
        }

        public void MovePlayer(Direction d)
        {
            try
            {
                PlayerPos = CheckMovement(PlayerPos,d);
            }
            catch (Exception) { }
        }
    }
}
