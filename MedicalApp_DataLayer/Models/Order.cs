﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public enum Status
    {
        Pending,
        Delivered,
        shipped,
        cancelled
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column("Status")]
        public Status Status { get; set; }
        public double Total { get; set; }

        [ForeignKey(nameof(Models.Pharmacy))]
        public string? PharmacyId { get; set; }
        public Pharmacy? Pharmacy { get; set; }
        [ForeignKey(nameof(Patient))]
        public string? PatientId { get; set; }
        public Patient? PatientObj { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<Pharmacy> Pharmices { get; set; }
        
        public Order() { 
            Items = new List<OrderItem>();

        }
    }
}
