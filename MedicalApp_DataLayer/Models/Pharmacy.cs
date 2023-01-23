using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class Pharmacy :User
    {
        [NotNull]
        public string? TxnNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public Pharmacy() { 
            Orders = new LinkedList<Order>();
            Products = new List<Product>();
        }
    }
}
