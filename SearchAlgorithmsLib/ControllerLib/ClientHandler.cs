using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;
using Newtonsoft.Json.Linq;
using ClientLib;

namespace ControllerLib
{

    public class ClientHandler : IClientHandler
    {

        IController controller;
        private bool run;

        public ClientHandler(IController c)
        {
            controller = c;
            run = true;
        }
        public void HandleClient(ClientOfServer client)
        {
            new Task(() => {
                while (client.IsConnected())
                {
                    // Receive the command from the client.
                    string commandLine = client.ReadFromClient();

                    if (!string.IsNullOrEmpty(commandLine))
                    {
                        Console.WriteLine("Received command: {0}", commandLine);

                        // Send the result to the client.
                        string result = controller.ExecuteCommand(commandLine, this, client);
                        client.WriteToClient(result);

                        // If the command is a single player command, 
                        // stop the connection to the client now.
                        if (Controller.DecypherCommand(commandLine) is SinglePlayerCommand)
                        {
                            client.DisconnectFromServer();
                        }
                    }
                }
            }).Start();
            new Task(() =>
            {
                JObject obj = new JObject();
                obj["close"] = "game-over";

                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    while (run)
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
                client.Close();
            }).Start();
        }
    }
}
