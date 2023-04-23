using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Rate
    {
        public int ID { get; set; }
        [ForeignKey(nameof(Clinic))]
        public string? ClinicId { get; set; }
        public Clinic? ClinicObj { get; set; }
        [ForeignKey(nameof(Patient))]
        public string? PatiantId { get; set; }
        public Patient? PatientObj { get; set; }
        [MaxLength(5)]
        public byte Number { get; set; }
    }
}
