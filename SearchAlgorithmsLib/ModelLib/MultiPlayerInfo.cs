using ClientLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    class MultiPlayerInfo
    {
        public ClientOfServer Host
        {
            get; set;
        }
        public ClientOfServer Guest
        {
            get; set;
        }
        public Maze Maze
        {
            get; set;
        }

        public MultiPlayerInfo()
        {
            Host = null;
            Guest = null;
            Maze = null;
        }

        public ClientOfServer GetTheOtherPlayer(ClientOfServer player)
        {
            if (Host.Equals(player))
            {
                return Guest;
            }

            if (Guest.Equals(player))
            {
                return Host;
            }

            throw new Exception("the player does not exist");
        }

        public bool ContainPlayer(ClientOfServer player)
        {
            if (Guest.Equals(player) || Host.Equals(player)) { return true; }
            return false;
        }
    }
}
