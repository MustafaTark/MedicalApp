using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class OrderForCreateDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string? PharmacyId { get; set; }
        public string? PatientId { get; set; }
        public ICollection<OrderItem>? Items { get; set; }
    }
}
