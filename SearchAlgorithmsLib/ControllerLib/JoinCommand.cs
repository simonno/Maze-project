using System.Net.Sockets;
using ModelLib;
using MazeLib;

namespace ControllerLib
{
    class JoinCommand : Command
    {
        public JoinCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            Maze maze = model.Join(name);
            return maze.ToJSON();
        }
    }
}
