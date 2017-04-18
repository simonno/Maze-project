using System;
using System.Net.Sockets;
using ModelLib;
using System.IO;

namespace ControllerLib
{
    class PlayCommand : MultiCommand
    {
        public PlayCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
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
