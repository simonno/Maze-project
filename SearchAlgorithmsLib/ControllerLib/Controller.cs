//using ModelLib;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;

//namespace ControllerLib
//{
//    class Controller
//    {
//        private Dictionary<string, ICommand> commands;
//        private IModel model;

//        public IModel Model
//        {
//            set { model = value; }
//        }

//        public Controller()
//        {
//            commands = new Dictionary<string, ICommand>
//            {
//                { "generate", new GenerateMazeCommand(model) }
//            };
//            more commands...
//        }
//        public string ExecuteCommand(string commandLine, TcpClient client)
//        {
//            string[] arr = commandLine.Split(' ');
//            string commandKey = arr[0];
//            if (!commands.ContainsKey(commandKey))
//                return "Command not found";
//            string[] args = arr.Skip(1).ToArray();
//            ICommand command = commands[commandKey];
//            return command.Execute(args, client);
//        }
//    }
//}