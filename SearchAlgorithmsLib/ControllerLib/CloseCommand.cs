﻿using System.Net.Sockets;
using ModelLib;
using System.IO;
using Newtonsoft.Json.Linq;
using ClientLib;

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
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string name = args[0];
            ClientOfServer otherPlayer = model.Close(name, client);
            if (otherPlayer != null)
            {
                otherPlayer.DisconnectFromServer();
            }
            client.DisconnectFromServer();
            return null;
        }
    }
}
