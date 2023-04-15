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
    public class ReportRepository : RepositoryBase<Report> , IReportRepository
    {
        public ReportRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
        public void CreateReport(Report report) => Create(report);
        public void DeleteReport(Report report) => Delete(report);

        public async Task<IEnumerable<Report>> GetAllReportsForClinic(string clinicId, bool trackChanges)
             => await FindByCondition(e => e.ClinicId == clinicId, trackChanges)
            .OrderBy(o => o.AppointmentObject!)
            .ToListAsync();
        public async Task<IEnumerable<Report>> GetAllReportsForPatient(string patientId, bool trackChanges)
            => await FindByCondition(e => e.PatientId == patientId, trackChanges)
             .OrderBy(o => o.AppointmentObject!)
             .ToListAsync();
        public async Task<Report?> GetReportById(Guid appointmentId, bool TrackChanges)
            => await FindByCondition(r => r.AppointmentId == appointmentId, TrackChanges)
             .SingleOrDefaultAsync();
    }
}
