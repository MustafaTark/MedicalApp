using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Task<Order?> GetOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersForPharmacyAsync(string PharmacyId);
        Task<IEnumerable<Order>> GetOrdersForPatientAsync(string PatientId);
        void DeleteOrdere(Order order);
    }
}
