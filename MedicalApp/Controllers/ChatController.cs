using MedicalApp.Hubs;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub, IChatClient> _messageHub;
        public ChatController(IHubContext<ChatHub, IChatClient> messageHub)
        {
            _messageHub = messageHub;
        }
        [HttpPost("messages")]
        public async Task<IActionResult> Post(ChatMessage message)
        {
            // run some logic...

            await _messageHub.Clients.All.ReceiveMessage(message);
            return Ok(message);
        }
    }
}
