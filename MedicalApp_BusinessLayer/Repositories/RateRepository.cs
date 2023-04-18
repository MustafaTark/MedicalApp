using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class RateRepository : RepositoryBase<Rate>, IRateRepository
    {
        public RateRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public void CreateRate(Rate rate)
         =>Create(rate);

        public async Task<double> GetOverallRate(string clinicId)
        {

              var rates = await FindByCondition(r=>r.ClinicId==clinicId,trackChanges:false)
                .Where(r => r.ClinicId == clinicId)
                .ToListAsync();
            return rates.Average(c => c.Number);
        }

        public async Task<IEnumerable<Rate>> GetRatesForClinic(string clinicId)
           => await FindByCondition(r => r.ClinicId == clinicId, trackChanges: false).ToListAsync();
        public async Task<int> GetSingleRateToPatient(string patientId, string clinicId)
          => await FindByCondition(p => p.PatiantId == patientId && p.ClinicId == clinicId, trackChanges: false)
                   .Select(r => r.Number).FirstOrDefaultAsync();
        public async Task UpdateRate(string patientId,string clinicId,int newNumber)
        {
            await FindByCondition(p => p.PatiantId == patientId && p.ClinicId == clinicId, trackChanges: true)
            .ExecuteUpdateAsync(r => r.SetProperty(r => r.Number,r=>(r.Number-r.Number)+newNumber));
        }
    }
}
