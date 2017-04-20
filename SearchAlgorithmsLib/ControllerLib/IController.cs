using ClientLib;

namespace ControllerLib
{
    public interface IController
    {
        string ExecuteCommand(string args, IClientHandler ch, ClientOfServer client = null);
    }
}
