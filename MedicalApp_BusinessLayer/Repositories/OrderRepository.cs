using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }


        public void CreateOrder(Order order)=>Create(order);
        

        public void DeleteOrdere(Order order) => Delete(order);

        public async Task<Order?> GetOrderAsync(int orderId)
              => await FindByCondition(o => o.Id.Equals(orderId), trackChanges: false)
            .Include(o => o.Items)
            .FirstOrDefaultAsync();
        public async Task<IEnumerable<Order>> GetOrdersForPharmacyAsync(string pharmacyId)
            => await FindByCondition(o => o.PharmacyId!.Equals(pharmacyId), trackChanges: false)
            .Include(o=>o.Items)
            .ToListAsync();
        public async Task<IEnumerable<Order>> GetOrdersForPatientAsync(string PatientId)
            => await FindByCondition(o => o.PatientId!.Equals(PatientId), trackChanges: false)
            .Include(o => o.Items)
            .ToListAsync();

    }
}
