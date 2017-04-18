using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{

    abstract class MultiCommand : Command
    {
        public MultiCommand(IModel model) : base(model)
        {
        }
    }
}
