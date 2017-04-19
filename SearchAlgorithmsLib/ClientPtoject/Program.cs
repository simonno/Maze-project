using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientPtoject
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            string commandLine = "";
            string answerServer;
            Console.Write("Please enter a command: ");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Task taskRead = new Task(() =>
                {
                    while (true)
                    {
                        try
                        {
                            if (client.Connected == false)
                            {
                                Thread.Sleep(2000);
                                continue;
                            }
                            answerServer = reader.ReadLine();
                            answerServer = answerServer.Replace("@", System.Environment.NewLine);
                            Console.WriteLine("Result = " + answerServer);
                        }
                        catch (SocketException)
                        {
                            Console.WriteLine("task read - socket exception");
                            break;
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
                            commandLine = Console.ReadLine();
                            if (client.Connected == false)
                            {
                                client.Connect(ep);
                                Console.WriteLine("You are connected");
                            }
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
            }
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