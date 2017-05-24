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
    public class ApplicationMultiPlayerModel : NotifyChanged, IMultiPlayerModel
    {
        private IPEndPoint socketInfo;
        private Maze maze;
        private StreamReader Reader;
        private StreamWriter Writer;
        private TcpClient tcpClient;
        private Direction opponentPos;
        private bool stopReading;

        public ApplicationMultiPlayerModel()
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);

        }

        public Direction OpponentPosChanged
        {
            get { return opponentPos; }
            set
            {
                opponentPos = value;
                NotifyPropertyChanged("OpponentPosChanged");
            }
        }

        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public string MazeToString
        {
            get
            {
                return maze.ToString();
            }
        }

        public string MazeName
        {
            get
            {
                return maze.Name;
            }
        }
        public int MazeRows
        {
            get
            {
                return maze.Rows;
            }
        }
        public int MazeCols
        {
            get
            {
                return maze.Cols;
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

        public async Task<string> aaa()
        {

            stopReading = false;
            string answer;
            while (!stopReading) { 
            answer = Reader.ReadLine();
            if (!string.IsNullOrEmpty(answer))
            {

                answer = answer.Replace("@", Environment.NewLine);
                PlayerDirection pd = PlayerDirection.FromJSON(answer);
                OpponentPosChanged = (Direction)Enum.Parse(typeof(Direction), pd.Move);
                await Task.Delay(500);
                stopReading = true;
            }
        }
            
            return "Success";
        }
            private void CreateReadTask()
        {

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

                  //  Application.Current.Dispatcher.Invoke((() => {
                        PlayerDirection pd = PlayerDirection.FromJSON(answer);

                          OpponentPosChanged = (Direction)Enum.Parse(typeof(Direction), pd.Move);
                     // }));
                   // Application.Current.Dispatcher.InvokeShutdown();
                }
            }
        }).Start();

        }


        private void Connect()
        {
            Console.WriteLine("Trying to connect to server");
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(socketInfo);
            }
            catch (SocketException s)
            {
                Console.WriteLine("ERROR: Connection failed.");
                throw s;
            }
            Console.WriteLine("Connection succeeded.");

            InitializeReader();
            InitializeWriter();
        }

        /// <summary>
        /// Initializes the reader.
        /// </summary>
        private void InitializeReader()
        {
            Reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Initializes the writer.
        /// </summary>
        private void InitializeWriter()
        {
            Writer = new StreamWriter(tcpClient.GetStream());
        }

        /// <summary>
        /// Disposes the writer and reader.
        /// </summary>
        private void Disconnect()
        {
            // Dispose the reader and writer.
            Reader.Dispose();
            Writer.Dispose();

            // Close the connection.
            tcpClient.Close();
            Console.WriteLine("Connection has closed.");
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
