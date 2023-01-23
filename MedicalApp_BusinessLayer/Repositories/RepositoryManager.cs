using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly  AppDbContext _context;
        private  IAppointmentRepository _appointment;
        private IClinicRepository _clinic;
        private IPatientRepository _Patient;
        private IClinicDaysRepository _clinicDayes;
        private IRateRepository _rate;
        private IFilesManager _filesManager;
        public RepositoryManager(IAppointmentRepository appointment,
            IClinicRepository clinic,
            AppDbContext context,
           IPatientRepository patient,
           IClinicDaysRepository clinicDays,
           IRateRepository rate,
           IFilesManager filesManager
            )
        {
            _appointment = appointment;
            _clinic = clinic;
            _Patient = patient;
            _context= context;
            _clinicDayes= clinicDays;
          _rate= rate;
            _filesManager = filesManager;
            
        }
        public IAppointmentRepository Appointment
        {
            get{
                if (_appointment is null)
                    _appointment = new AppointmentRepository(_context);
                
                return _appointment;
            }
            
        }

       public IClinicRepository Clinic
        {
            get
            {
                if (_clinic is null)
                  _clinic = new ClinicRepository(_context,_filesManager);
                
                return _clinic;
            }
        }
        public IPatientRepository Patient { 
            get
            {
                if(_Patient is null)
                    _Patient = new PatientRepository(_context,_filesManager);
                return _Patient;
            }
        }
        public IClinicDaysRepository ClinicDays
        {
            get
            {
                if (_clinicDayes is null)
                    _clinicDayes = new ClinicDayRepository(_context);
                return _clinicDayes;
            }
        }
        public IRateRepository RateRepository
        {
            get
            {
                if (_rate is null)
                    _rate = new RateRepository(_context);
                return _rate;
            }
        }

     

        public  Task SaveChanges() =>  _context.SaveChangesAsync();

     
    }
}
