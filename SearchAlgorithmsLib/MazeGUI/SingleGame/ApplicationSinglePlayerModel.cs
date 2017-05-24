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
    public class ApplicationSinglePlayerModel : NotifyChanged, ISinglePlayerModel
    {
        private List<List<int>> mazeCells;
        private int defaultSearchAlgorithm;
        private Maze maze;
        private Point playerPos;
        private IPEndPoint socketInfo;
        private TcpClient tcpClient;
        private StreamReader Reader;
        private StreamWriter Writer;
        

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
            playerPos = new Point(0,0) ;
            CreateMazeCells(MazeToString);
        }

        private void CreateMazeCells(string mazeToString)
        {
            mazeCells = new List<List<int>>(MazeRows);
            for (int i = 0; i < MazeRows; i++)
            {
                mazeCells.Add(new List<int>(MazeCols));
                for (int j = 0; mazeToString[j + i * MazeCols].ToString() != Environment.NewLine; j++)
                {
                    Char c = mazeToString[j + i * MazeCols];
                    if (c == '1')
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");

                    }

                }
                Console.WriteLine("");
            }
        }

        public void ChangePlayerPos(Direction d)
        {
            int x = PlayerPos.Y;
            int y = PlayerPos.X;
            Point temp;
            switch (d)
            {
                case Direction.Up:
                    temp = new Point(x, y - 1);
                    break;

                case Direction.Down:
                    temp = new Point(x, y + 1);
                    break;

                case Direction.Right:
                    temp = new Point(x + 1, y);
                    break;

                case Direction.Left:
                    temp = new Point(x - 1, y);
                    break;
                default:
                    return;
            }
            if(isValidPos(temp))
            {
                PlayerPos = temp;
            }

        }

        private bool isValidPos(Point temp)
        {
            if (mazeCells[temp.X][temp.Y] == 0)
                return true;
            return false;
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

        public Point PlayerPos
        {
            get { return playerPos; }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("PlayerPos");
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

        public string MazeToString
        {
            get
            {
                return maze.ToString();
            }
        }
        
        public MazeSolution Solve()
        {

            Connect();

            //string command = "solve "+ maze.Name+ " "+ defaultSearchAlgorithm;


            Writer.WriteLine("solve {0} {1}", maze.Name, defaultSearchAlgorithm);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);

            MazeSolution ms;
            ms = MazeSolution.FromJSON(answer);
            Disconnect();
            return ms;
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
