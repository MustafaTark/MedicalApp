using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }
        public City? CityObj { get; set; }
        public string? Region { get; set; }
       

    }
}
