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
        IClinicDaysRepository ClinicDays { get; }
        IRateRepository RateRepository { get; }
        
        Task SaveChanges();
    }
}
