using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientProject
{
    class Program
    {
         void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            string commandLine = "";
            string answerServer;
            //Console.Write("Please enter a command: ");

            //using (NetworkStream stream = client.GetStream())
            //using (StreamReader reader = new StreamReader(stream))
            //using (StreamWriter writer = new StreamWriter(stream))
            //{
                Task taskRead = new Task(() =>
                {
                    while (true)
                    {
                        if (IsClientConnected(client))
                        {
                            StreamReader reader = new StreamReader(client.GetStream());
                            try
                            {
                                answerServer = reader.ReadLine();
                                if (answerServer != null)
                                {
                                    answerServer = answerServer.Replace("@", System.Environment.NewLine);
                                    Console.WriteLine("Result = " + answerServer);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("task read - socket exception");
                                continue;
                            }

                        } else
                        {
                            Thread.Sleep(2000);

                        }


                    }
                    Console.WriteLine("stop reading");
                });
                taskRead.Start();

                Task taskWrite = new Task(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please enter a command: ");
                            commandLine = Console.ReadLine();
                            if (!IsClientConnected(client))
                            {
                                client.Connect(ep);
                                Console.WriteLine("You are connected");
                            }
                            StreamWriter writer = new StreamWriter(client.GetStream());
                            writer.AutoFlush = true;
                            writer.WriteLine(commandLine);
                        }
                        catch (SocketException)
                        {
                            Console.WriteLine("task write - socket exception");
                            break;
                        }
                    }
                    Console.WriteLine("stop writing");

                });
                taskWrite.Start();
                taskWrite.Wait();
            //}
        }
        /// <summary>
        /// THIS FUNCTION WILL CHECK IF CLIENT IS STILL CONNECTED WITH SERVER.
        /// </summary>
        /// <returns>FALSE IF NOT CONNECTED ELSE TRUE</returns>
        static bool IsClientConnected(TcpClient ClientSocket)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation c in tcpConnections)
            {
                TcpState stateOfConnection = c.State;

                if (c.LocalEndPoint.Equals(ClientSocket.Client.LocalEndPoint) && c.RemoteEndPoint.Equals(ClientSocket.Client.RemoteEndPoint))
                {
                    if (stateOfConnection == TcpState.Established)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            return false;
        }
    }
}




//try
//        {


//                //commandLine = Console.ReadLine();

//                //writer.AutoFlush = true;
//                //writer.WriteLine(commandLine);

//                // if (commandLine.Length>4&&(
//                // commandLine.Substring(0, 5).Equals("solve")
//                //|| commandLine.Substring(0, 8).Equals("generate") ))
//                // {//single player
//                //     answerServer = reader.ReadLine();
//                //     answerServer = answerServer.Replace("@", System.Environment.NewLine);
//                //     //string a = (string)JsonConvert.DeserializeObject(answerServer);
//                //     Console.WriteLine("Result = " + answerServer);
//                //     client.Close();
//                // }
//                // else
//                // {//multi player


//                while (true)
//                {
//                    commandLine = Console.ReadLine();
//                    if (string.IsNullOrEmpty(commandLine))
//                    {
//                        if (client.Connected == false)
//                        {
//                            client.Connect(ep);
//                            Console.WriteLine("You are connected");
//                        }
//                        try
//                        {
//                            writer.AutoFlush = true;
//                            writer.WriteLine(commandLine);
//                            break;
//                        }
//                        catch (SocketException)
//                        { 
//                        }

//                    }
//                    answerServer = reader.ReadLine();
//                    if (string.IsNullOrEmpty(answerServer))
//                    {
//                        answerServer = answerServer.Replace("@", System.Environment.NewLine);
//                        Console.WriteLine("Result = " + answerServer);
//                    }

//                }
//            }

//        }

//        catch (SocketException ex)
//        {
//            Console.WriteLine(ex);
//        }
//        client.Close();