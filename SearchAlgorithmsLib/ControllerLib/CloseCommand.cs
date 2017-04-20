using System.Net.Sockets;
using ModelLib;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ControllerLib
{
    /// <summary>
    /// define the close command
    /// </summary>
    /// <seealso cref="ControllerLib.MultiCommand" />
    class CloseCommand : MultiCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public CloseCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments abstract method.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// string of the command
        /// </returns>
        public override string Execute(string[] args, IClientHandler ch, TcpClient client = null)
        public override string Execute(string[] args, ClientOfServer ch, TcpClient client = null)
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
