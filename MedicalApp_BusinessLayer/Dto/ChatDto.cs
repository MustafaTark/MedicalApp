using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string? ClinicId { get; set; }
        public Clinic? ClinicObj { get; set; }
        public string? PatientId { get; set; }
        public Patient? PatientObj { get; set; }
    }
}
