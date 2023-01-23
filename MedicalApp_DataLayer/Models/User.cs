using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public  class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; } = "Not Found";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }

    }
}
