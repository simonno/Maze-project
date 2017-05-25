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
        private bool stopReading2;
        private Queue<string> coma;

        public ApplicationMultiPlayerModel()
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
            coma = new Queue<string>();

        }

        public Position OpponentPos
        {
            get { return opponentPos; }
            set
            {
                opponentPos = value;
                Console.WriteLine(opponentPos);

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

        /// <summary>
        /// Creates the read task.
        /// </summary>
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
                        //Thread.Sleep(5000);
                        answer = answer.Replace("@", Environment.NewLine);
                        coma.Enqueue(answer);
                        //PlayerDirection pd = PlayerDirection.FromJSON(answer);
                        //Thread.Sleep(5000);

                        // UpDateOpponentPos(pd.Move);
                    }
                    // Thread.Sleep(1000);
                }
            }).Start();
            new Task(() =>
            {
                stopReading2 = false;
                string answer2;
                while (!stopReading2)
                {
                    while (coma.Count > 0)
                    {
                        answer2 = "";
                        string o = coma.Dequeue();
                        if (o.Contains("Direction"))
                        {
                            PlayerDirection pd = PlayerDirection.FromJSON(o);
                            UpDateOpponentPos(pd.Move);
                            Thread.Sleep(1000);

                        }
                    }
                }

            }).Start();
        }
            /// <summary>
            /// Ups the date opponent position.
            /// </summary>
            /// <param name="move">The move.</param>
            private  void UpDateOpponentPos(Direction move)
        {
            try
            {
                OpponentPos =  CheckMovement(OpponentPos,move);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="move">The move.</param>
        public void MovePlayer(Direction move)
        {
            try
            {
                PlayerPos = CheckMovement(PlayerPos,move);
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
