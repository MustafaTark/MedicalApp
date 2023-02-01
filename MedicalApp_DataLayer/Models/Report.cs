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
        //public ICollection<Product> Products { get; set;}
        //public Report() { 
        //    Products = new List<Product>();
        //}
        [ForeignKey(nameof(Appointment))]
        public Guid Appointment { get; set; }
        public Appointment? AppointmentObject { get; set; }
    }
}
