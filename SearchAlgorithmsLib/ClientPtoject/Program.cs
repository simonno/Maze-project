using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            try
            {
                // while (!commandLine.Equals("close"))
                //{
                Console.Write("Please enter a command: ");

                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    commandLine = Console.ReadLine();

                    writer.AutoFlush = true;
                    writer.WriteLine(commandLine);
                    // if (commandLine.Length>4&&(
                    // commandLine.Substring(0, 5).Equals("solve")
                    //|| commandLine.Substring(0, 8).Equals("generate") ))
                    // {//single player
                    //     answerServer = reader.ReadLine();
                    //     answerServer = answerServer.Replace("@", System.Environment.NewLine);
                    //     //string a = (string)JsonConvert.DeserializeObject(answerServer);
                    //     Console.WriteLine("Result = " + answerServer);
                    //     client.Close();
                    // }
                    // else
                    // {//multi player
                    //     Task taskRead = new Task(() =>
                    //     {
                    //         while (true)
                    //         {
                    //             try
                    //             {
                    //                 answerServer = reader.ReadLine();
                    //                 answerServer = answerServer.Replace("@", System.Environment.NewLine);
                    //                 Console.WriteLine("Result = " + answerServer);
                    //             }
                    //             catch (SocketException)
                    //             {
                    //                 break;
                    //             }
                    //         }
                    //         Console.WriteLine("stop reading");
                    //     });
                    //     taskRead.Start();

                    //     Task taskWrite = new Task(() =>
                    //     {
                    //         while (true)
                    //         {
                    //             try
                    //             {
                    //                 writer.AutoFlush = true;
                    //                 writer.WriteLine(commandLine);
                    //             }
                    //             catch (SocketException)
                    //             {
                    //                 break;
                    //             }
                    //         }
                    //         Console.WriteLine("stop writing");

                    // });
                    // taskWrite.Start();

                    while (true)
                    {
                        answerServer = reader.ReadLine();

                    }
                }

                // }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            client.Close();
        }
    }
}

