using MedicalApp_DataLayer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Configrations
{
    public class UniqueTxnNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext))!;
            if (dbContext.Clinics.Any(x => x.TxnNumber == (string)value))
            {
                return new ValidationResult(ErrorMessage);
            }
            if (dbContext.Pharmacies.Any(x => x.TxnNumber == (string)value))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}
