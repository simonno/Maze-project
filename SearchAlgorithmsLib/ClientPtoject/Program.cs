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
            string commandLine="" ;
            string answerServer;

            while (!commandLine.Equals("close"))
            {
                Console.Write("Please enter a command: ");

                using (NetworkStream stream = client.GetStream())
                using (StreamReader readerFromServer = new StreamReader(stream))
                using (StreamWriter writerToServer = new StreamWriter(stream))
                {
                    commandLine = Console.ReadLine();
                    writerToServer.Write(commandLine);
                     answerServer = readerFromServer.ReadLine();
                    Console.WriteLine("Result = " + answerServer);

                }
            }
            client.Close();



        }
    }
}

