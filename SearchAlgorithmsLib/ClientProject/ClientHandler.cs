using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;

namespace ServerProject
{

    public class ClientHandler : IClientHandler
    {
        IController controller;

        public ClientHandler(IController c)
        {
            controller = c;
        }
        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string commandLine = reader.ReadLine();

                    Console.WriteLine("Got command: {0}", commandLine);
                    string result = ExecuteCommand(commandLine, client);
                    result = result.Replace(System.Environment.NewLine, "@");
                    result += System.Environment.NewLine;
                    writer.Flush();
                    writer.Write(result);

                }
                client.Close();
            }).Start();
        }

        private string ExecuteCommand(string commandLine, TcpClient client)
        {
            return controller.ExecuteCommand(commandLine, client);
        }
    }
}
