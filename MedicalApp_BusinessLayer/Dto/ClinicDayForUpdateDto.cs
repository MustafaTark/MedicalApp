using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class ClinicDayForUpdateDto
    {
        public string? Day { get; set; }
        public string? ClinicId { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
    }
}
