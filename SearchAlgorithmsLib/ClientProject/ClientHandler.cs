using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;
using Newtonsoft.Json.Linq;

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
                JObject obj = new JObject();
                obj["close"] = "game-over";
                while (true)
                {
                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        try
                        {
                            string commandLine = reader.ReadLine();
                            Console.WriteLine("Got command: {0}", commandLine);
                            string result = ExecuteCommand(commandLine, client);
                            if (result == obj.ToString()) { break; }
                            result = result.Replace(System.Environment.NewLine, "@");
                            result += System.Environment.NewLine;
                            writer.Flush();
                            writer.Write(result);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
              //  client.Close();
            }).Start();
        }

        private string ExecuteCommand(string commandLine, TcpClient client)
        {
            return controller.ExecuteCommand(commandLine, client);
        }
    }
}
