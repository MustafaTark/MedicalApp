using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ClinicDayDto
    {
        public string? Day { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
    }
}
