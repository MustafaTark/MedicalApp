using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> GetAllClinics();
        Task<Clinic?> GetClinicById(string id);
        void DeleteClinic(Clinic clinic);
        void UploadImage(IFormFile fil,string clinicId);
        FileStream GetImage(string clinicId);
    }
}
