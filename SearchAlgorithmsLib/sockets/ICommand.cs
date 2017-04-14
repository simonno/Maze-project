using System;
using System.Net.Sockets;

namespace ServerProject
{
    interface ICommand
    {
        string Execute(string [] command, TcpClient client = null);
    }
}
