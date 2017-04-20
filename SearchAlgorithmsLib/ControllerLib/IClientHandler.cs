using ClientLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    public interface IClientHandler
    {
        void HandleClient(ClientOfServer client);
        void StopConnetion();

    }
}
