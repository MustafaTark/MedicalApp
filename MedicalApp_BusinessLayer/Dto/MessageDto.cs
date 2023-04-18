using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class MessageDto
    {
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public string? Role { get; set; }
    }
}
