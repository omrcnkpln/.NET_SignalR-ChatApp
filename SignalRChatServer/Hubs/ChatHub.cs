using Microsoft.AspNetCore.SignalR;
using SignalRChatServer.Data;
using SignalRChatServer.Models;

namespace SignalRChatServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task GetNickname(string nickname)
        {
            Client client = new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickname,
            };

            ClientSource.Clients.Add(client);
            await Clients.Others.SendAsync("clientJoined", nickname);
        }
    }
}
