using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
