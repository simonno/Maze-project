using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;

namespace ServerProject
{
    class ProgramServer
    {
        static void Main(string[] args)
        {
            IController controller = new Controller();
            ClientHandler ch = new ClientHandler(controller);
            Server server = new Server(8000, ch);
            server.Start();
            server.Stop();

        }
    }
}
