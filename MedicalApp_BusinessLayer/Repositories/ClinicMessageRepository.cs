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
    public class ClinicMessageRepository : RepositoryBase<ClinicMessage>, IClinicMessageRepository
    {
        public ClinicMessageRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateMessage(ClinicMessage message)
         =>Create(message);

        public void DeleteMessage(ClinicMessage message)
          => Delete(message);

        public async Task<IEnumerable<ClinicMessage>> GetClinicMessages(Guid chatId)
         => await FindByCondition(c => c.ChatId == chatId,trackChanges:false).ToListAsync();
    }
}
