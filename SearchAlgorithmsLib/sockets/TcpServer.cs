﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerProject
{
    class TcpServer
    {
        static void Main(string[] args)
        {
            IClientHandler ch = new ClientHandler();
            Server server = new Server(8005, ch);
            server.Start();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                Console.WriteLine("Waiting for a number");
                int num = reader.ReadInt32();
                Console.WriteLine("Number accepted");
                num *= 2;
                writer.Write(num);
                Console.ReadLine();


            }

            client.Close();
            listener.Stop();

        }
    }
}
