using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace MedicalApp.Hubs
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class ChatHub : Hub<IChatClient>
    {
        //public async Task SendMessage(MessageDto message)
        //{
        //    await Clients.All.ReceiveMessage(message);
        //}
    }
}
