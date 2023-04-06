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
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp_DataLayer.Models
{
  
    public class Clinic:User
    {
       
        [NotNull]
        public string? TxnNumber { get; set; }
        [NotNull]
        public string? DoctorName { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? CategoryObj { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public ICollection<ClinicDayes> Dayes { get; set; }
        public Clinic()
        {
            Dayes= new List<ClinicDayes>();
        }
    }
}
