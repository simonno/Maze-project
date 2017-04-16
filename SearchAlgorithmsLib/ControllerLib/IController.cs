using System.Net.Sockets;

namespace ControllerLib
{
    public interface IController
    {
        string ExecuteCommand(string args, TcpClient client = null);
    }
}
