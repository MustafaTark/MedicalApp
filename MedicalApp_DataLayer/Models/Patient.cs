using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Patient :User
    {
        public Patient()
        {
            Reports = new List<Report>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Age { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}
