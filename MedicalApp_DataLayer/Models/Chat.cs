using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Clinic))]
        public string? ClinicId { get; set; }
        public Clinic? ClinicObj { get; set;}
        [ForeignKey(nameof(Patient))]
        public string? PatientId { get; set; }
        public Patient? PatientObj { get; set; }
        public ICollection<ClinicMessage> ClinicMessages { get; set; }
        public ICollection<PatientMessage> PatientMessages { get; set; }
        public Chat()
        {
            ClinicMessages=new List<ClinicMessage>();
            PatientMessages=new List<PatientMessage>();
        }
    }
}
