using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace MazeGUI.MultiGame
{
    class ApplicationMultiPlayerModel:IMultiPlayerDetailsModel
    {
        private IPEndPoint socketInfo;
        private Maze maze;
        private StreamReader Reader;
        private StreamWriter Writer;
        private TcpClient tcpClient;

        public Maze Start()
        {

            Connect();
            
            Writer.WriteLine("solve {0} {1} {2}", maze.Name, maze.Rows ,maze.Cols);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);

            Maze ms;
            ms = Maze.FromJSON(answer);
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
