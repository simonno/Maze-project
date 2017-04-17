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
        public TcpClient Host
        {
            get; set;
        }
        public TcpClient Guest
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

        public TcpClient GetTheOtherPlayer(TcpClient player)
        {
            if (Host == player)
            {
                return Guest;
            }

            if (Guest == player)
            {
                return Host;
            }

            throw new Exception("the player does not exist");
        }

        public bool ContainPlayer(TcpClient player)
        {
            if (Guest == player || Host == player) { return true; }
            return false;
        }
    }
}
