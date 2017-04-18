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
    class SolveCommand : SingleCommand
    {
        public SolveCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int typeSolve = int.Parse(args[1]);
            MazeSolution s = model.Solve(name, typeSolve);
            return s.ToJSON();
        }
    }
}
