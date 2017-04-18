using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ControllerLib
{
    abstract class SingleCommand : Command
    {
        public SingleCommand(IModel model) : base(model)
        {
        }
    }
}
