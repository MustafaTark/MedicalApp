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
    public class PatientMessageRepository : RepositoryBase<PatientMessage>, IPatientMessageRepository
    {
        public PatientMessageRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public void CreateMessage(PatientMessage message)
          => Create(message);

        public void DeleteMessage(PatientMessage message)
         =>Delete(message);

        public async Task<IEnumerable<PatientMessage>> GetPatientMessages(Guid chatId)
         => await FindByCondition(c => c.ChatId == chatId, trackChanges: false).ToListAsync();
    }
}
