using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class ChatRepository :RepositoryBase<Chat>, IChatRepository
    {
        public ChatRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public void CreateChat(Chat chat)
          => Create(chat);

        public async Task<Chat?> GetChatByIdAsync(Guid id)
         => await FindByCondition(c => c.Id == id, trackChanges: false)!.FirstOrDefaultAsync()!;
    }
}
