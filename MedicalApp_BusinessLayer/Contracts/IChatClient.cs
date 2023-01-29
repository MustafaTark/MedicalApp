using MedicalApp_BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
