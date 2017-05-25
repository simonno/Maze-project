using MazeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    public abstract class Model : NotifyChanged
    {
        protected List<List<int>> mazeCells;
        protected Maze maze;
        protected Position playerPos;
        protected IPEndPoint socketInfo;
        protected TcpClient tcpClient;
        protected StreamReader Reader;
        protected StreamWriter Writer;

        protected void CreateMazeCells(string mazeToString)
        {
            string[] rowsStinrgs = mazeToString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int rowIndex = 0;
            mazeCells = new List<List<int>>(MazeRows);
            foreach (String row in rowsStinrgs)
            {
                mazeCells.Add(new List<int>(MazeCols));

                for (int i = 0; i < MazeCols; i++)
                {
                    if (row[i] == '1')
                        mazeCells[rowIndex].Insert(i, 1);
                    else
                        mazeCells[rowIndex].Insert(i, 0);
                }
                rowIndex++;
            }
        }

        public Position CheckMovement(Direction d)
        {
            int x = PlayerPos.Col;
            int y = PlayerPos.Row;
            Position temp;
            switch (d)
            {
                case Direction.Up:
                    temp = new Position(y - 1, x);
                    break;

                case Direction.Down:
                    temp = new Position(y + 1, x);
                    break;

                case Direction.Right:
                    temp = new Position(y, x + 1);
                    break;

                case Direction.Left:
                    temp = new Position(y, x - 1);
                    break;

                default:
                    throw new Exception("Unvalid movement.");

            }
            if (IsValidPos(temp))
                return temp;

            else throw new Exception("Unvalid movement.");
        }

        protected bool IsValidPos(Position pos)
        {
            if (pos.Col < MazeCols && pos.Row < MazeRows && pos.Col >= 0 && pos.Row >= 0 && mazeCells[pos.Row][pos.Col] == 0)
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

        public Position PlayerPos
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

        public Position InitialPos
        {
            get
            {
                return maze.InitialPos;
            }
        }

        public Position GoalPos
        {
            get
            {
                return maze.GoalPos;
            }
        }

        protected void Connect()
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
        protected void InitializeReader()
        {
            Reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Initializes the writer.
        /// </summary>
        protected void InitializeWriter()
        {
            Writer = new StreamWriter(tcpClient.GetStream());
        }

        /// <summary>
        /// Disposes the writer and reader.
        /// </summary>
        protected void Disconnect()
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
