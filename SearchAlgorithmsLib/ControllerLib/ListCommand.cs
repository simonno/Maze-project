using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;
using ClientLib;

namespace ControllerLib
{
    class ListCommand : SingleCommand
    {
        public ListCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, IClientHandler ch = null, ClientOfServer client = null)
        {
            return JsonConvert.SerializeObject(model.List());
        }
    }
}
