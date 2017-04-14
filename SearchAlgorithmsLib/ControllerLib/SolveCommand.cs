using MazeLib;
using ModelLib;
using Newtonsoft.Json;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    class SolveCommand : ICommand
    {
        private IModel model;
        public SolveCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int typeSolve = int.Parse(args[1]);
            MazeSolution s = model.Solve(name, typeSolve);
            return JsonConvert.SerializeObject(s);
        }


    }
}
