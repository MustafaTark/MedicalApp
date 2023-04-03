using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IRateRepository
    {
        Task<IEnumerable<Rate>> GetRatesForClinic(string clinicId);
        void CreateRate(Rate rate);
        Task<double> GetOverallRate(string clinicId);
    }
}
