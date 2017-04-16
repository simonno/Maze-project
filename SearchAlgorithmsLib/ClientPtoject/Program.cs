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
                while (!commandLine.Equals("close"))
                {
                    Console.Write("Please enter a command: ");

                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        commandLine = Console.ReadLine();
                        writer.AutoFlush = true;
                        writer.WriteLine(commandLine);
                        answerServer = reader.ReadLine();
                        string a = answerServer.ToString();
                        string afterConvert = "";
                        for(int i=0; i<a.Length; i++)
                        {if (a[i] == '@')
                            {
                                afterConvert += "\n";
                            }
                            else
                            {
                                afterConvert += a[i];
                            }

                        }
                        Console.WriteLine("Result = " + afterConvert);

                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            client.Close();



        }
    }
}

