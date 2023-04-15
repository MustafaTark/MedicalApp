using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IReportRepository
    {
        void CreateReport(Report report); //string appointmentId
        Task<IEnumerable<Report>> GetAllReportsForClinic(string clinicId, bool trackChanges);
        Task<IEnumerable<Report>> GetAllReportsForPatient(string patientId, bool trackChanges);
        Task<Report?> GetReportById(Guid appointmentId, bool trackChanges);
        void DeleteReport(Report report);
    }
}
