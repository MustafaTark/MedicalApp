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

        public async Task<IEnumerable<Chat>> GetAllToClinic(string clinicId)
           => await FindByCondition(c=>c.ClinicId==clinicId,trackChanges:false).ToListAsync();

        public async Task<IEnumerable<Chat>> GetAllToPatient(string patientId)
           => await FindByCondition(c => c.PatientId == patientId, trackChanges: false).ToListAsync();

        public async Task<Chat?> GetChatByIdAsync(Guid id)
         => await FindByCondition(c => c.Id == id, trackChanges: false)!.FirstOrDefaultAsync()!;

        public async Task<Guid> GetChatToPatientAndClinic(string patientId, string clinicId)
        {
            var chatId = await FindByCondition(c => c.PatientId == patientId && c.ClinicId == clinicId, trackChanges: false)
                             .Select(c => c.Id)
                             .FirstOrDefaultAsync();
            return chatId;
         }
    }
}
