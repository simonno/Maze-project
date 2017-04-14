using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{ 
    public interface IController
    {
        string ExecuteCommand(string args, TcpClient client = null);
    }
}
