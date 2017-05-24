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
          
            CreateReadTask();
          
        }

        private void CreateReadTask()
        {   // create a thread  
            Thread newThread = new Thread(new ThreadStart(() =>
            {
                // start the Dispatcher processing  
                //System.Windows.Threading.Dispatcher.Run();

                stopReading = false;
                string answer;
                while (!stopReading)
                {
                    answer = Reader.ReadLine();
                    if (!string.IsNullOrEmpty(answer))
                    {
                        answer = answer.Replace("@", Environment.NewLine);
                        PlayerDirection pd = PlayerDirection.FromJSON(answer);
                        //OpponentPosChanged = (Direction)Enum.Parse(typeof(Direction), pd.Move);
                    }
                    Thread.Sleep(500);
                }
            }));

            // set the apartment state  
            newThread.SetApartmentState(ApartmentState.STA);

            // make the thread a background thread  
            newThread.IsBackground = true;

            // start the thread  
            newThread.Start();
            //new Task(() =>
            //{
                
            //}).Start();
        }


        public void Play(Direction d)
        {
            string move="";
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
           // var result = aaa();
        }
        public void Close(string mazeName)
        {
            Writer.WriteLine("close {0}", mazeName);
            Writer.Flush();
        }
    }
}
