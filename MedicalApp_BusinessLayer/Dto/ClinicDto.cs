using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ClinicDto
    {
        public string? PhoneNumber { get; set; }
        public string? TxnNumber { get; set; }
        public string? DoctorName { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public ICollection<ClinicDayDto>? Dayes { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
    }
}
