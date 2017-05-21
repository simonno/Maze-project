﻿using ClientLib;
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
//using ModelLib;

namespace MazeGUI.SingleGame
{
    public class ApplicationSinglePlayerModel : ISinglePlayerModel
    {
        private int defaultSearchAlgorithm;
        private Maze maze;
        private IPEndPoint socketInfo;
        private TcpClient tcpClient;
        private StreamReader Reader;
        private StreamWriter Writer;
        private MazeSolution sol;

        public ApplicationSinglePlayerModel(string mazeName, int rows, int cols)
        {
            //maze.Name = "noam $ meital";
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
            defaultSearchAlgorithm = Properties.Settings.Default.SearchAlgorithm;
            GenerateMaze(mazeName, rows, cols);
       //     sol = Solve();
        }

        private void GenerateMaze(string mazeName, int rows, int cols)
        {
            Connect();
            Writer.Flush();
            Writer.WriteLine("generate {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            maze = Maze.FromJSON(answer);
            Disconnect();
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
        //public string MazeSolution
        //{
        //    get
        //    {
        //        return sol.ToString();
        //    }
        //}
        public MazeSolution Solve()
        {

            Connect();
            // Writer.WriteLine("solve" + maze.Name + "{0}", defaultSearchAlgorithm);
            //MazeSolution s = ModelLib.ServerModel.Solve(MazeName, defaultSearchAlgorithm);

            string command = "solve "+ maze.Name+ " "+ defaultSearchAlgorithm;
      

            Writer.WriteLine(command);
            Writer.Flush();

            //MazeSolution s = new MazeSolution();
            //s.Solve(maze, defaultSearchAlgorithm);
            //client.WriteToClient(s.ToJSON());
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", System.Environment.NewLine);

            MazeSolution ms;
            ms = ModelLib.MazeSolution.FromJSON(answer);
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