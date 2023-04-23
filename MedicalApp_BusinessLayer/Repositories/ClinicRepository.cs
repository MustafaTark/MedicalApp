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
    public class ClinicRepository:RepositoryBase<Clinic>,IClinicRepository
    {
        private readonly IFilesManager _filesManager;
        public ClinicRepository(AppDbContext dbContext, IFilesManager filesManager) : base(dbContext) {
            _filesManager= filesManager;
        }

        public void DeleteClinic(Clinic clinic)
        {
            var chats = _context.Chats.Where(c => c.ClinicId == clinic.Id).ToList();
            var clinicMessages = new List<ClinicMessage>();
            foreach (var chat in chats)
            {
                var messages = _context.ClinicMessages.Where(c => c.Id == chat.Id).ToList();
                clinicMessages.AddRange(messages!);
            }
            _context.ClinicMessages.RemoveRange(clinicMessages);
            _context.Chats.RemoveRange(chats);
            Delete(clinic);
        }

        public async Task<IEnumerable<Clinic>> GetAllClinics(ClinicParamters paramters)
         =>await FindAll(trackChanges: false).Include(c=>c.Dayes).Include(c=>c.CityObj)
            .Search(paramters.SearchTerm!,paramters.Category!,paramters.City!)
            .Skip((paramters.PageNumber - 1) * paramters.PageSize)
            .Take(paramters.PageSize)
            .ToListAsync();

        public async Task<Clinic?> GetClinicById(string clincId , bool trackChanges)
          => await FindByCondition(c => c.Id == clincId, trackChanges).Include(c => c.CityObj)
            .Include(c => c.CategoryObj)
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

        public void UpdateClinic(Clinic clinic)
         => Update(clinic);
    }
}
