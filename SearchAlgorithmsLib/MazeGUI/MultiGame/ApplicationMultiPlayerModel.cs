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

namespace MazeGUI.MultiGame
{
    public class ApplicationMultiPlayerModel : ANotifyPropertyChanged, IMultiPlayerModel
    {
        private IPEndPoint socketInfo;
        private Maze maze;
        private StreamReader Reader;
        private StreamWriter Writer;
        private TcpClient tcpClient;

        public ApplicationMultiPlayerModel()
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);

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
            OpenReadTask();
        }

        public void Join(string mazeName)
        {
            Connect();
            Writer.WriteLine("join {0}", mazeName);
            Writer.Flush();
            OpenReadTask();
        }

        private void OpenReadTask()
        {
            new Task(() =>
            {
                string answer = Reader.ReadLine();
                answer = answer.Replace("@", Environment.NewLine);
                Maze = Maze.FromJSON(answer);



                //bool stop = false;
                //while (!stop)
                //{
                //    answer = Reader.ReadLine();
                //    answer = answer.Replace("@", Environment.NewLine);
                //    PlayerDirection pd = PlayerDirection.FromJSON(answer);

                //}
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


    }
}
