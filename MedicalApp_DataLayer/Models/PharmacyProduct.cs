using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Models
{
    public class PharmacyProduct
    {
        [ForeignKey(nameof(Models.Pharmacy))]
        public required string PharmacyId { get; set; }
        public Pharmacy? Pharmacy { get; set; }
        [ForeignKey(nameof(Models.Product))]
        public required int ProductId { get; set; }
        public Product? Product { get; set; }


    }
}
