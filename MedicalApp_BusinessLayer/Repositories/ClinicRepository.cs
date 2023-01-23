using MedicalApp_BusinessLayer.Contracts;
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
    public class ClinicRepository:RepositoryBase<Clinic>,IClinicRepository
    {
        private readonly IFilesManager _filesManager;
        public ClinicRepository(AppDbContext dbContext, IFilesManager filesManager) : base(dbContext) {
            _filesManager= filesManager;
        }

        public  void DeleteClinic(Clinic clinic)
         =>Delete(clinic);

        public async Task<IEnumerable<Clinic>> GetAllClinics()
         =>await FindAll(trackChanges: false).ToListAsync();

        public async Task<Clinic?> GetClinicById(string clincId)
          => await FindByCondition(c => c.Id == clincId, trackChanges: false)
            .Include(c=>c.Dayes).FirstOrDefaultAsync()!;

        public void  UploadImage(IFormFile file,string clincId)
        {
         string fileName=   _filesManager.UploadFiles(file);
             FindByCondition(c => c.Id == clincId, trackChanges: true)
               .FirstOrDefault()!.ImageUrl=fileName;
        }
        public FileStream GetImage(string clinicId)
        {
           var image= FindByCondition(c => c.Id == clinicId, trackChanges: true)
               .FirstOrDefault()!.ImageUrl;
            return _filesManager.GetFile(image!);
        }
    }
}
