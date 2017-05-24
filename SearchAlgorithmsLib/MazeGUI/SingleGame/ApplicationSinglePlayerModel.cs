using ClientLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using ModelLib;
using System.Drawing;
//using ModelLib;

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


        public MazeSolution Solve()
        {
            Connect();
            Writer.WriteLine("solve {0} {1}", maze.Name, defaultSearchAlgorithm);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);

            return MazeSolution.FromJSON(answer);
        }
    }
}
