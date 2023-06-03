using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description {  get; set; }
        public double Price { get; set;}
        public string? ImageUrl { get; set; }
        public ICollection<Pharmacy> Pharmacies { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Product()
        {
            Pharmacies = new List<Pharmacy>();
            OrderItems = new List<OrderItem>();
        }
    }
}
