using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IPatientRepository
    {
        Task<Patient?> GetPatientByIdAsync(string id);
        void DeletePatient(Patient patient);
        void UploadImage(IFormFile fil, string patientId);

        FileStream GetImage(string patientId);
    }
}
