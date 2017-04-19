using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    abstract class Command : ICommand
    {
        protected IModel model;
        public Command(IModel model)
        {
            this.model = model;
        }

        public abstract string Execute(string[] args, IClientHandler ch = null, TcpClient client = null);
    }
}
