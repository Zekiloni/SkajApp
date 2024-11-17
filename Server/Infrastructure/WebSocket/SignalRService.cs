using Microsoft.AspNetCore.SignalR;

namespace Server.Infrastructure.WebSocket
{
    public class SignalRService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastMessageAsync(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToGroupAsync(string groupName, string user, string message)
        {
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }

        public async Task AddToGroupAsync(string connectionId, string groupName)
        {
            await _hubContext.Groups.AddToGroupAsync(connectionId, groupName);
        }

        public async Task RemoveFromGroupAsync(string connectionId, string groupName)
        {
            await _hubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
        }
    }
}
