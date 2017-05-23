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
    public class ApplicationMultiPlayerModel : IMultiPlayerModel
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
            get { return List(); }
        }
        private List<string> List()
        {
            Connect();

            Writer.WriteLine("list");
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            return JsonConvert.DeserializeObject<List<string>>(answer);
            //string list = answer;
            //int i = list.Length - 1;
            //List<string> p = new List<string>();
            //string name;
            //for (int j = 0; j <= i; j++)
            //{
            //    if ((list[j] == '"'))
            //    {
            //        j = j + 1;
            //        if (list[j + 1] != ',')
            //        {
            //            name = "";
            //            while (list[j] != '"')
            //            {
            //                name += list[j];
            //                j++;
            //            }
            //            p.Add(name);
            //        }
            //    }
            //}
            //return p;
        }
        public void Start(string mazeName, int rows, int cols)
        {

            Connect();
          //  OpenReadTask();
            Writer.WriteLine("start {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();


            //// TODO "waiting for connection" win

            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            Maze ms;
            ms = Maze.FromJSON(answer);

            maze = ms;
            MultiPlayer mp = new MultiPlayer();
            mp.Show();
            //Disconnect();
        }

        private void OpenReadTask()
        {
            new Task(() =>
            {
                string answer = Reader.ReadLine();
                answer = answer.Replace("@", Environment.NewLine);
                maze = Maze.FromJSON(answer); 
                MultiPlayer mp = new MultiPlayer();
                mp.Show();
                

                bool stop = false;
                while (!stop)
                {
                    answer = Reader.ReadLine();
                    answer = answer.Replace("@", Environment.NewLine);
                    PlayerDirection pd = PlayerDirection.FromJSON(answer);

                }
            }).Start();
        }

        public void Join(string mazeName)
        {
            Connect();
            //OpenReadTask();
            Writer.WriteLine("join {0}", mazeName);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);

            Maze ms;
            ms = Maze.FromJSON(answer);
            maze = ms;
            MultiPlayer mp = new MultiPlayer();
            mp.Show();


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
