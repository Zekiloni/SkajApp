using Microsoft.AspNetCore.SignalR;

namespace Server.Infrastructure.WebSocket
{
    public class ChatHub : Hub
    {
        private readonly SignalRService _signalRService;

        public ChatHub(SignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        public async Task SendMessage(string user, string message)
        {
            await _signalRService.BroadcastMessageAsync(user, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await _signalRService.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await _signalRService.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
        }
    }
}
