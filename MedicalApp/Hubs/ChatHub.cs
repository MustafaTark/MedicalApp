using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Services;
using Microsoft.AspNetCore.SignalR;

namespace MedicalApp.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
