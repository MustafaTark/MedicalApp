using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IRepositoryManager
    {
        IAppointmentRepository Appointment { get; }
        IClinicRepository Clinic { get; }
        IPatientRepository Patient { get; }
        IAdminRepository Admin { get; }
        IClinicDaysRepository ClinicDays { get; }
        IRateRepository RateRepository { get; }
        IChatRepository Chat { get; }
        IClinicMessageRepository ClinicMessage { get; }
        IPatientMessageRepository PatientMessage { get; }
        IPharmacyRepository Pharmacy { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IReportRepository Report { get; }
        Task<IEnumerable<City>> GetCityAsync();
        Task<IEnumerable<Category>> GetCategories();
        Task SaveChanges();
    }
}
