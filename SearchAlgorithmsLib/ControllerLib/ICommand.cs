using ClientLib;
using System;
using System.Net.Sockets;

namespace ControllerLib
{
    interface ICommand
    {
        string Execute(string[] args, IClientHandler ch = null, ClientOfServer client = null);
    }
}
