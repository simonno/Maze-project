﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using System.Threading;

namespace ControllerLib
{
    class StartCommand : Command
    {
        public StartCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            model.Start(name, rows, cols);
            while (!model.IsPair(name)) {
                Thread.Sleep(2000);
            }
            return model.GetMaze(name).ToJSON();
        }
    }
}