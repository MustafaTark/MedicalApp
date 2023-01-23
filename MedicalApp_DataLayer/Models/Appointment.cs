using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    [Index("ClinicId")]
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsAvailable { get; set; }
       
        [ForeignKey(nameof(Clinic))]
        public string? ClinicId { get; set; }
        [ForeignKey(nameof(Patient))]
        public string? PatiantId { get; set; }
      
    }
}
