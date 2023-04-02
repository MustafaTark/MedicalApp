using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.ExtentionsRepo;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_BusinessLayer.Services;
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
    public class PharmacyRepository :RepositoryBase<Pharmacy> , IPharmacyRepository
    {
        public PharmacyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public void DeletePharmacy(Pharmacy pharmacy) => Delete(pharmacy);

        public async Task<IEnumerable<Pharmacy?>> GetAllPharmaciesAsync(PharmacyParamters paramters, bool trackChanges)
           => await FindAll(trackChanges).Include(p => p.CityObj)
            .Search(paramters.SearchTerm!, paramters.City!)
            .Skip((paramters.PageNumber - 1) * paramters.PageSize)
            .Take(paramters.PageSize)
            .ToListAsync();
        public async Task<Pharmacy?> GetPharmacyByIdAsync(string pharmacyId, bool trackChanges) 
            => await FindByCondition(p => p.Id.Equals(pharmacyId), trackChanges).Include(p => p.CityObj)
            .FirstOrDefaultAsync();
    }
}
