using Azure;
using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsToClinicAsync(string clinicId);
        Task<IEnumerable<Appointment>> GetAllAppointmentsToPatientAsync(string patientId);
        bool CheckAppointmentAvailability(Guid id);
        Task<Appointment?> GetAppointmentByIdAsync(Guid id);
        void CreateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);

    }
}
