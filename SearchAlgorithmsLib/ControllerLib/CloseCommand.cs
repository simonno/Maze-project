using System.Net.Sockets;
using ModelLib;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ControllerLib
{
    class CloseCommand : MultiCommand
    {
        public CloseCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, IClientHandler ch, TcpClient client = null)
        {
            JObject obj = new JObject();
            obj["close"] = "game-over";
            TcpClient otherPlayer = model.Close(client);
            using (NetworkStream stream = otherPlayer.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                writer.Write(obj.ToString());
            }
            ch.StopConnetion();
            return obj.ToString();
        }
    }
}
