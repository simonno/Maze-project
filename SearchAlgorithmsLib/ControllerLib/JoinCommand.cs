using System.Net.Sockets;
using ModelLib;
using MazeLib;
using ClientLib;

namespace ControllerLib
{
    class JoinCommand : MultiCommand
    {
        public JoinCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, IClientHandler ch = null, ClientOfServer client = null)
        {
            string name = args[0];
            Maze maze = model.Join(name,client);
            return maze.ToJSON();
        }
    }
}
