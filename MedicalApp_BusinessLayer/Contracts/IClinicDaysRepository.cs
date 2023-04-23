using MedicalApp_BusinessLayer.ViewModels;
using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IClinicDaysRepository
    {
        Task<IEnumerable<ClinicDayVM>> GetClinicDayes(string clinicId);
        Task<ClinicDayes?> GetClinicDay(int clinicDayId);
        void Create(List<ClinicDayes> clinicDayes);
        void DeleteClinicDay(ClinicDayes clinicDay);
        void UpdateClinicDayes(ClinicDayes clinicDayes);

    }
}
