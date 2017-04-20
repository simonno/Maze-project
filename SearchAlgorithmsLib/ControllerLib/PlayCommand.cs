using System;
using System.Net.Sockets;
using ModelLib;
using System.IO;

namespace ControllerLib
{
    /// <summary>
    ///  define the command play
    /// </summary>
    /// <seealso cref="ControllerLib.MultiCommand" />
    class PlayCommand : MultiCommand
    {
        /// <summary>
        /// Initializes a new instance of the play command <see cref="PlayCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>the string of play command</returns>
        public override string Execute(string[] args, IClientHandler ch = null, TcpClient client = null)
        {
            Tuple<TcpClient, PlayerDirection> otherPlayerInfo = model.Play(args[0], client);
            TcpClient otherPlayer = otherPlayerInfo.Item1;
            using (NetworkStream stream = otherPlayer.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;
                writer.Write(otherPlayerInfo.Item2.ToJSON());
            }
            return null;
        }
    }
}
