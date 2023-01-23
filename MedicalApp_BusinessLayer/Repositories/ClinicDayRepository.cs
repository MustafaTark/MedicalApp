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
    public class ClinicDayRepository
        :
        RepositoryBase<ClinicDayes>, IClinicDaysRepository
    {
        private new readonly AppDbContext _context;
        public ClinicDayRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public void Create(List<ClinicDayes> clinicDayes)
         => _context.Set<ClinicDayes>().AddRange(clinicDayes);

        public void DeleteClinicDay(ClinicDayes clinicDay)
         => Delete(clinicDay);

        public async Task<ClinicDayes?> GetClinicDay(int clinicDayId)
          => await FindByCondition(c => c.ID == clinicDayId, trackChanges: false).FirstOrDefaultAsync();

        public async Task<IEnumerable<ClinicDayes>> GetClinicDayes(string clinicId)
          => await FindByCondition(c => c.ClinicId == clinicId, trackChanges: false).ToListAsync();
    }
}
