using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Net.Sockets;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ModelLib;
using System.Threading;
using System.Drawing;
using System.Windows.Threading;
using System.Windows;

namespace MazeGUI.MultiGame
{
    public class ApplicationMultiPlayerModel : Model, IMultiPlayerModel
    {

        private Position opponentPos;
        private bool stopReading;

        public ApplicationMultiPlayerModel()
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public Position OpponentPos
        {
            get { return opponentPos; }
            set
            {
                opponentPos = value;
                NotifyPropertyChanged("OpponentPos");
            }
        }

        public List<string> GamesList
        {
            get
            {
                Connect();
                Writer.WriteLine("list");
                Writer.Flush();
                string answer = Reader.ReadLine();
                answer = answer.Replace("@", Environment.NewLine);
                Disconnect();
                return JsonConvert.DeserializeObject<List<string>>(answer);
            }
        }

        public void Start(string mazeName, int rows, int cols)
        {
            Connect();
            Writer.WriteLine("start {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();
            GetMaze();
        }

        public void Join(string mazeName)
        {
            Connect();
            Writer.WriteLine("join {0}", mazeName);
            Writer.Flush();
            GetMaze();
        }

        private void GetMaze()
        {
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            Maze = Maze.FromJSON(answer);
            PlayerPos = Maze.InitialPos;
            OpponentPos = Maze.InitialPos;
            CreateMazeCells(MazeToString);
            CreateReadTask();

        }

        private void CreateReadTask()
        {   // create a task  
            new Task(() =>
            {
                stopReading = false;
                string answer;
                while (!stopReading)
                {
                    answer = Reader.ReadLine();
                    if (!string.IsNullOrEmpty(answer))
                    {
                        answer = answer.Replace("@", Environment.NewLine);
                        PlayerDirection pd = PlayerDirection.FromJSON(answer);
                        UpDateOpponentPos(pd.Move);

                    }
                    Thread.Sleep(500);
                }
            }).Start();
        }

        private void UpDateOpponentPos(Direction move)
        {
            try
            {
                OpponentPos = CheckMovement(move);
            }
            catch (Exception) { }
        }

        public void MovePlayer(Direction move)
        {
            try
            {
                PlayerPos = CheckMovement(move);
                UpdateServer(move);
            }
            catch (Exception) { }
        }

        private void UpdateServer(Direction d)
        {
            string move = "";
            switch (d)
            {
                case Direction.Left:
                    move = "Left";
                    break;
                case Direction.Right:
                    move = "Right";
                    break;
                case Direction.Up:
                    move = "Up";
                    break;
                case Direction.Down:
                    move = "Down";
                    break;

            }
            Writer.WriteLine("play {0}", move);
            Writer.Flush();
        }

        public void Close(string mazeName)
        {
            Writer.WriteLine("close {0}", mazeName);
            Writer.Flush();
        }
    }
}
