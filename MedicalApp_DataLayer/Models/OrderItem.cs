using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int Quntity { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey(nameof(Models.Product))]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order? OrderObj { get; set; }

    }
}
