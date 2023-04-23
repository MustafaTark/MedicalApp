using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class PatientMessage
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(Chat))]
        public Guid? ChatId { get; set; }
        public Chat? ChatObj { get; set; }
    }
}
