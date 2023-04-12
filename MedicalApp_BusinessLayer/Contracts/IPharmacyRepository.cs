using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IPharmacyRepository
    {
        Task<Pharmacy?> GetPharmacyByIdAsync(string pharmacyId, bool trackChanges);
        Task<IEnumerable<Pharmacy?>> GetAllPharmaciesAsync(PharmacyParamters paramters, bool trackChanges);
        void DeletePharmacy(Pharmacy pharmacy);
        void UploadImage(IFormFile file, string pharmacyId);
        FileStream GetImage(string pharmacyId);
        void AssignProductsForPharmacy(string pharmacyId, List<int> Ids);


    }
}
