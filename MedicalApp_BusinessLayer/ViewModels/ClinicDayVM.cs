using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.ViewModels
{
    public class ClinicDayVM
    {
        public string? Day { get; set; } 
        public List<string>? Times { get; set; }
    }
}
