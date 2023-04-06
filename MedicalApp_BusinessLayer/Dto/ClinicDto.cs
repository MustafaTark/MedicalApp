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
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TxnNumber { get; set; }
        public string? DoctorName { get; set; }
        public int? CategoryId { get; set; }
        public string? Email { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public ICollection<ClinicDayDto>? Dayes { get; set; }
        public string? Address { get; set; }
        public City? CityObj { get; set; }
        public string? Region { get; set; }
    }
}
