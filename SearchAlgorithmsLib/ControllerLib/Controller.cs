using ClientLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ControllerLib
{
    public class Controller : IController
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;
        public IModel Model
        {
            set { model = value; }
        }

        public Controller(IModel imodel)
        {
            Model = imodel;
            commands = new Dictionary<string, ICommand>
            {
                { "generate", new GenerateMazeCommand(model) },
                { "solve", new SolveCommand(model) },
                { "start", new StartCommand(model) },
                { "list", new ListCommand(model) },
                { "play", new  PlayCommand(model) },
                { "join", new  JoinCommand(model) },
                { "close", new CloseCommand(model) }
            };
        }

        public string ExecuteCommand(string commandLine, IClientHandler ch, ClientOfServer client = null)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            //if  (command is SingleCommand || command is CloseCommand)
            //{
            //    ch.StopConnetion();
            //}
            return command.Execute(args, ch, client);
        }
    }
}