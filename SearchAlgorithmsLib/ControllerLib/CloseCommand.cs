using System.Net.Sockets;
using ModelLib;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ControllerLib
{
    class CloseCommand : Command
    {
        public CloseCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
           TcpClient otherPlayer = model.Close(client);
            using (NetworkStream stream = otherPlayer.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                JObject obj = new JObject();
                writer.AutoFlush = true;
                writer.Write(obj.ToString());
            }
            return null;
        }
    }
}
