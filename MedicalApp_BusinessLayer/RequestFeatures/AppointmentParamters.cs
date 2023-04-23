using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.RequestFeatures
{
    public class AppointmentParamters
    {
        public string? Time { get; set; }
        public string? ClinicId { get; set; }
        public string? PatientId { get; set; }
        public int Day { get; set; }  
    }
}
