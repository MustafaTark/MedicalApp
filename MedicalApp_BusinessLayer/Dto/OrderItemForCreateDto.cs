using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class OrderItemForCreateDto
    {
        public double Total { get; set; }
        public int Quntity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
    }
}
