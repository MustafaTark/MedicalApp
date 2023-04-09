using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.ExtentionsRepo;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IFilesManager _filesManager;
        public PharmacyRepository(AppDbContext dbContext, IFilesManager filesManager) : base(dbContext)
        {
            _filesManager = filesManager;
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

        public void UploadImage(IFormFile file, string pharmacyId)
        {
            string fileName = _filesManager.UploadFiles(file);
            FindByCondition(p => p.Id == pharmacyId, trackChanges: true)
              .FirstOrDefault()!.ImageUrl = fileName;
        }
        public FileStream GetImage(string pharmacyId)
        {
            var image = FindByCondition(c => c.Id == pharmacyId, trackChanges: true)
                .FirstOrDefault()!.ImageUrl;
            return _filesManager.GetFile(image!);
        }

        public void AssignProductsForPharmacy(string pharmacyId, List<int> ids)
        {
            var pharmacy = FindByCondition(p => p.Id == pharmacyId, trackChanges: false);
            foreach (var id in ids)
            {
                var product = _context.Products.Where(p => p.ID == id).SingleOrDefault();
                _context.Set<Pharmacy>().FirstOrDefault(p => p.Id == pharmacyId)!.Products.Add(product!);

            }
        }


    }
}
