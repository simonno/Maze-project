using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject
{

    /// <summary>
    /// Client
    /// </summary>
    public class Client
    {
        private JObject Jobj;

        /// <summary>
        /// The TCP client
        /// </summary>
        private TcpClient tcpClient;

        /// <summary>
        /// The reader
        /// </summary>
        public StreamReader Reader;

        public void Close()
        {
            tcpClient.Close();
        }

        /// <summary>
        /// The writer
        /// </summary>
        public StreamWriter Writer;

        /// <summary>
        /// The reading task running
        /// </summary>
        public bool ReadingTaskRunning;

        /// <summary>
        /// The writing task running
        /// </summary>
        public bool WritingTaskRunning;

        private IPEndPoint socketInfo;


        public Client(string IP, int port)
        {
            socketInfo = new IPEndPoint(IPAddress.Parse(IP), port);
            Jobj = new JObject();
            Jobj["close"] = "game-over";
        }

        /// <summary>
        /// Connects this client to the server.
        /// </summary>
        public void Connect()
        {
            tcpClient = new TcpClient();
            Reconnect();
            StartWritingTask();
        }

        private void Reconnect()
        {
            Console.WriteLine("Trying to connect to server");
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
            StartReadingTask();
        }

        /// <summary>
        /// Reads result from the server.
        /// </summary>
        /// <returns> the resulting string </returns>
        public string Read()
        {
            // Receive the result from the server.
            string result = Reader.ReadLine();

            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("@", System.Environment.NewLine);
                Console.WriteLine(result);
            }

            if (!IsConnected() || result.Equals(Jobj.ToString()))
            {
                Disconnect();
            }

            return result;
        }

        /// <summary>
        /// Writes a command to the server.
        /// </summary>
        public void Write()
        {
            // Send the command to the server.
            string command = Console.ReadLine();

            if (!IsConnected())
            {
                Reconnect();
            }

            Writer.WriteLine(command);
            Writer.Flush();
        }

        /// <summary>
        /// Determines whether this client is connected.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            return tcpClient.Connected;
        }

        /// <summary>
        /// Disposes the writer and reader.
        /// </summary>
        private void Disconnect()
        {
            // Dispose the reader and writer.
            Reader.Dispose();
            Writer.Dispose();

            // Stop the client from constantly reading from server.
            ReadingTaskRunning = false;

            // Close the connection.
            tcpClient.Close();
            Console.WriteLine("Connection has closed.");
        }

        /// <summary>
        /// Starts the reading task.
        /// </summary>
        public void StartReadingTask()
        {
            ReadingTaskRunning = true;

            new Task(() =>
            {
                while (ReadingTaskRunning)
                {
                    Read();
                }
            }).Start();
        }

        /// <summary>
        /// Starts the writing task.
        /// </summary>
        public void StartWritingTask()
        {
            WritingTaskRunning = true;

            new Task(() =>
            {
                while (WritingTaskRunning)
                {
                    Write();
                }
            }).Start();
        }

        /// <summary>
        /// Initializes the reader.
        /// </summary>
        public void InitializeReader()
        {
            Reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Initializes the writer.
        /// </summary>
        public void InitializeWriter()
        {
            Writer = new StreamWriter(tcpClient.GetStream());
        }
    }
}

