using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class PatientDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
    }
}
