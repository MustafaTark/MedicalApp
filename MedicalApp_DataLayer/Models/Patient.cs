using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="First Name is Required Field")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required Field")]
        public string? LastName { get; set; }
        public byte? Age { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}
