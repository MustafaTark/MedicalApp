using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class AppointmentRepository:RepositoryBase<Appointment>, IAppointmentRepository
    {
      
        public AppointmentRepository(AppDbContext repositeryContext) : base(repositeryContext)
        {
          
        }

        public async Task<bool> CheckAppointmentAvailability(AppointmentParamters paramters)
        {
            var time =TimeSpan.Parse(paramters.Time!);
            
           var clinicAppointment = await  FindByCondition(a => a.ClinicId== paramters.ClinicId
                                                 && a.Time.Equals(time)&& a.Date.Day == paramters.Day,
                                                 trackChanges: true).FirstOrDefaultAsync();
            var patientAppointment= await FindByCondition(a => a.PatiantId == paramters.PatientId
                                                 && a.Time.Equals(time)&& a.Date.Day == paramters.Day
                                                  , trackChanges: true).FirstOrDefaultAsync();

            if (clinicAppointment is null && patientAppointment is null)
            {
                return true;
            }
            return false;
        }


        public void CreateAppointment(Appointment appointment)
        {
            appointment.IsAvailable=false;
            Create(appointment);
        }
       

        public void DeleteAppointment(Appointment appointment)
          =>Delete(appointment);

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsToClinicAsync(string clinicId)
          => await FindByCondition(a => a.ClinicId == clinicId, trackChanges: false).ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsToPatientAsync(string patientId)
            => await FindByCondition(a => a.PatiantId == patientId, trackChanges: false).ToListAsync();

        public async Task<Appointment?> GetAppointmentByIdAsync(Guid id)
          => await FindByCondition(a => a.ID! == id, trackChanges: false)!.FirstOrDefaultAsync()!;
    }
}
