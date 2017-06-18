using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class SinglePlayerModel:ISinglePlayer
    {
        private static List<SinglePlayer> singlePlayers = new List<SinglePlayer>()
        {
            new SinglePlayer { Mazename = "1", mazeRows = 5, mazeCols = 5,mazeString="hh" },
            new SinglePlayer {Mazename = "2", mazeRows = 5, mazeCols = 35,mazeString="h3h" },
            new SinglePlayer { Mazename = "22", mazeRows = 5, mazeCols = 35,mazeString="hxdv3h"  }
        };
        public string GetName(int id)
        {
            SinglePlayer p = singlePlayers.Where(x => x.Id == id).FirstOrDefault();
            return p.Mazename;
        }
        public int GetCols(int id)
        {
            SinglePlayer p = singlePlayers.Where(x => x.Id == id).FirstOrDefault();
            return p.mazeCols;
        }
        public int GetRows(int id)
        {
            SinglePlayer p = singlePlayers.Where(x => x.Id == id).FirstOrDefault();
            return p.mazeRows;
        }
        public string GetStringMaze(int id)
        {
            SinglePlayer p = singlePlayers.Where(x => x.Id == id).FirstOrDefault();
            return p.mazeString;
        }
    }
}