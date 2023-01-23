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
    public class RateRepository : RepositoryBase<Rate>, IRateRepository
    {
        public RateRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public void CreateRate(Rate rate)
         =>Create(rate);

        public async Task<IEnumerable<Rate>> GetRatesForClinic(string clinicId)
           => await FindByCondition(r => r.ClinicId == clinicId, trackChanges: false).ToListAsync();
    }
}
