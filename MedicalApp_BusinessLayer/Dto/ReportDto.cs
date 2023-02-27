using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ReportDto
    {
        public string? Description { get; set; }
        //public string? PatientId { get; set; }
        public Guid AppointmentId { get; set; }

    }
}
