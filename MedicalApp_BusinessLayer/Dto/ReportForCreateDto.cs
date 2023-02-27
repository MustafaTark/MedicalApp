using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ReportForCreateDto
    {
        public string? Description { get; set; }
        public Guid AppointmentId { get; set; }
        public string? PatientId { get; set; }
        public string? ClinicId { get; set; }

    }
}
