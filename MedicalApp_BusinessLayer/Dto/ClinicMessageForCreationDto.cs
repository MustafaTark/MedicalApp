using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ClinicMessageForCreationDto
    {
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public Guid? ChatId { get; set; }
    }
}
