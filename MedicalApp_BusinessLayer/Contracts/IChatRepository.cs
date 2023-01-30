using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IChatRepository
    {
        Task<Chat?> GetChatByIdAsync(Guid id);
        void CreateChat(Chat chat);
    }
}
