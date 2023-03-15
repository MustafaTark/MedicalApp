using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace MedicalApp_DataLayer.Models
{
  
    public class Clinic:User
    {
       
        [NotNull]
        public string? TxnNumber { get; set; }
        [NotNull]
        public string? DoctorName { get; set; }
        public string? Category { get; set; }//enum
        public ICollection<ClinicDayes> Dayes { get; set; }
        public Clinic()
        {
            Dayes= new List<ClinicDayes>();
        }
    }
}
