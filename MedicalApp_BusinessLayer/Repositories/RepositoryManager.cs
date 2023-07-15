using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
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
        private IChatRepository _chat;
        private IClinicMessageRepository _clinicMessage;
        private IPatientMessageRepository _patientMessage;
        private IPharmacyRepository _pharmacy;
        private IProductRepository _product;
        private IOrderRepository _order;
        private IReportRepository _report;
        //private IAdminRepository _admin;
        public RepositoryManager(IAppointmentRepository appointment,
            IClinicRepository clinic,
            AppDbContext context,
           IPatientRepository patient,
           IClinicDaysRepository clinicDays,
           IRateRepository rate,
           IFilesManager filesManager,
           IChatRepository chat,
           IClinicMessageRepository clinicMessage,
           IPatientMessageRepository patientMessage,
           IPharmacyRepository pharmacy,
           IProductRepository product,
           IOrderRepository order,
           IReportRepository report
           //IAdminRepository admin

            )
        {
            _appointment = appointment;
            _clinic = clinic;
            _Patient = patient;
            _context= context;
            _clinicDayes= clinicDays;
          _rate= rate;
            _filesManager = filesManager;
            _chat= chat;
            _clinicMessage= clinicMessage;
            _patientMessage= patientMessage;
            _chat= chat;
            _clinicMessage= clinicMessage;
            _patientMessage= patientMessage;
            _order= order;
            _pharmacy= pharmacy;
            _product= product;
            _report= report;
            //_admin= admin;
            
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
        //public IAdminRepository Admin
        //{
        //    get
        //    {
        //        if (_admin is null)
        //            _admin = new AdminRepository(_context, _filesManager);
        //        return _admin;
        //    }
        //}
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
        public IChatRepository Chat
        {
            get
            {
                if (_chat is null)
                    _chat = new ChatRepository(_context);
                return _chat;
            }
        }
        public IClinicMessageRepository ClinicMessage
        {
            get
            {
                if (_clinicMessage is null)
                    _clinicMessage = new ClinicMessageRepository(_context);
                return _clinicMessage;
            }
        }
        public IPatientMessageRepository PatientMessage
        {
            get
            {
                if (_patientMessage is null)
                    _patientMessage = new PatientMessageRepository(_context);
                return _patientMessage;
            }
        }

        public IPharmacyRepository Pharmacy
        {
            get
            {
                if (_pharmacy is null)
                    _pharmacy = new PharmacyRepository(_context, _filesManager);
                return _pharmacy;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_product is null)
                    _product = new ProductRepository(_context , _filesManager);
                return _product;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if (_order is null)
                    _order = new OrderRepository(_context);
                return _order;
            }
        }
        public IReportRepository Report
        {
            get
            {
                if(_report is null)
                    _report = new ReportRepository(_context);
                return _report;
            }
        }

        public async  Task<IEnumerable<City>> GetCityAsync()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public  Task SaveChanges() =>  _context.SaveChangesAsync();

     
    }
}
