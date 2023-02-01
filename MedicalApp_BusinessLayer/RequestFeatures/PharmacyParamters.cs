using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.RequestFeatures
{
    public class PharmacyParamters : RequestParamters
    {
        public string? SearchTerm { get; set; }
        public string? City { get; set; }
    }
}
