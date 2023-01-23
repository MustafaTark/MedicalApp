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
    public class PatientRepository :RepositoryBase<Patient>, IPatientRepository
    {
        private readonly IFilesManager _filesManager;
        public PatientRepository(AppDbContext context,IFilesManager filesManager) : base(context)
        {
            _filesManager = filesManager;
        }

        public void DeletePatient(Patient patient)
           => Delete(patient);

        public async Task<Patient?> GetPatientByIdAsync(string id)
          => await FindByCondition(p=>p.Id==id,trackChanges:false).FirstOrDefaultAsync();
        public void UploadImage(IFormFile file, string patientId)
        {
            string fileName = _filesManager.UploadFiles(file);
            FindByCondition(c => c.Id == patientId, trackChanges: true)
              .FirstOrDefault()!.ImageUrl = fileName;
        }
        public FileStream GetImage(string patientId)
        {
            var image = FindByCondition(c => c.Id == patientId, trackChanges: true)
                .FirstOrDefault()!.ImageUrl;
            return _filesManager.GetFile(image!);
        }
    }
}
