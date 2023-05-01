using MedicalApp_DataLayer.Configrations;
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
        [UniqueTxnNumber(ErrorMessage = "TxnNumber already exists.")]
        public string? TxnNumber { get; set; }
        public bool IsDisable { get; set; } = false;
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public Pharmacy() { 
            Orders = new LinkedList<Order>();
            Products = new List<Product>();
        }
    }
}
