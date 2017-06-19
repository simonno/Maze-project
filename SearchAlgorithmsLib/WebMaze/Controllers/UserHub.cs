using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;

namespace WebMaze.Controllers
{
    public class UserHub : Hub
    {
        private static ConcurrentDictionary<string, string> connectedPlayers =
            new ConcurrentDictionary<string, string>();

        private static ConcurrentDictionary<string, string> opponnents =
            new ConcurrentDictionary<string, string>();


        public void Register(string userName)
        {
            connectedPlayers[userName] = Context.ConnectionId;
        }

        public void Move(string userName, int direction)
        {
            string opponnentUsername = opponnents[userName];
            //string recipientId = connectedPlayers[recipientPhoneNum];
           // if (recipientId == null)
                return;
          //  Clients.Client(recipientId).gotMessage(senderPhoneNum, text);
        }

    }
}