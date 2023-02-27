using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public Report()
        {
            Products = new List<Product>();
        }
        [ForeignKey(nameof(Appointment))]
        public Guid AppointmentId { get; set; }
        public Appointment? AppointmentObject { get; set; }

        [ForeignKey(nameof(Patient))]
        public string? PatientId { get; set; }
        public Patient? PatientObject { get; set; }

        [ForeignKey(nameof(Clinic))]
        public string? ClinicId { get; set; }
        public Clinic? ClinicObject { get; set; }
    }
}
