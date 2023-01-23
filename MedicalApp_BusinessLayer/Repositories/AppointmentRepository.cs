using MedicalApp_BusinessLayer.Contracts;
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

        public bool CheckAppointmentAvailability(Guid appointmenId)
            => FindByCondition(a => a.ID==appointmenId, trackChanges: false).FirstOrDefault()!.IsAvailable ?
                true : false;


        public void CreateAppointment(Appointment appointment)
          => Create(appointment);

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
