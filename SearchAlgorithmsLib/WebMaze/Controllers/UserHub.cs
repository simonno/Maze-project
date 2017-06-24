using MazeLib;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class UserHub : Hub
    {
        private static ConcurrentDictionary<string, MultiPlayerInfo> waitingGames =
            new ConcurrentDictionary<string, MultiPlayerInfo>();

        private static ConcurrentDictionary<string, MultiPlayerInfo> runningGames =
            new ConcurrentDictionary<string, MultiPlayerInfo>();

        IMultiPlayerModel model = new MultiPlayerModel();


        public void Start(string name, int rows, int cols)
        {
            Maze maze = model.GenerateMaze(name, rows, cols);
            MultiPlayerInfo mpInfo = new MultiPlayerInfo()
            {
                Maze = maze,
                Host = Context.ConnectionId,
            };
            waitingGames[name]= mpInfo;
        }

     
        public void Join(string name)
        {
            if (waitingGames.ContainsKey(name))
            {
                waitingGames.TryRemove(name, out MultiPlayerInfo mp);
                mp.Guest = Context.ConnectionId;
                runningGames[name] = mp;
                string jsonMaze = mp.Maze.ToJSON();
                Clients.Client(mp.Host).notify(jsonMaze);
                Clients.Client(mp.Guest).notify(jsonMaze);
            }
        }

        public void List()
        {
            ICollection<string> namesCollaction = waitingGames.Keys;
            string[] temp = new string[namesCollaction.Count];
            namesCollaction.CopyTo(temp, 0);
            string list = JsonConvert.SerializeObject(temp);
            Clients.Client(Context.ConnectionId).notify(list);
        }

        public void Move(string userName, int direction)
        {
            // string opponnentUsername = opponnents[userName];
            //string recipientId = connectedPlayers[recipientPhoneNum];
            // if (recipientId == null)
            return;
            //  Clients.Client(recipientId).gotMessage(senderPhoneNum, text);
        }

    }
}