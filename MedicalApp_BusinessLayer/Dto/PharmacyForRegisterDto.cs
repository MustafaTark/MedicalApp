using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class PharmacyForRegisterDto
    {
        [Required(ErrorMessage = "Username is required")] 
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TxnNumber { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public ICollection<string> Roles { get; set; }
        public PharmacyForRegisterDto()
        {
            Roles = new List<string>();
        }
    }
}
