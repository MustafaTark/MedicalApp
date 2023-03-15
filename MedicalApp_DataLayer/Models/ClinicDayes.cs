using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class ClinicDayes
    {
     
        public int ID { get; set; }
        public string? Day { get; set; }//enum
        [ForeignKey(nameof(Clinic))]
        public string? ClinicId { get; set; }
        public Clinic? ClinicObject { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
