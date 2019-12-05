using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AddressBook.Application.Notifications
{
    public class NotificationHub : Hub
    {
        public const string Url = "/api/hubs/notification";

        public override Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}