using Microsoft.AspNetCore.SignalR.Client;

namespace Client.Core
{
    public class SignalRService
    {
        private HubConnection _hubConnection;

        public SignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7139")
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task StartConnectionAsync()
        {
            _hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine($"Message received: {message}");
            });

            await _hubConnection.StartAsync();
            Console.WriteLine("SignalR connection started.");
        }

        public async Task SendMessageAsync(string message)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.SendAsync("SendMessage", message);
            }
        }
    }
}
