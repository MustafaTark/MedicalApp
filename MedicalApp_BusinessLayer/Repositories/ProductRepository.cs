using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.ExtentionsRepo;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private new readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public void AddProductsToPharmacy(string pharmacyId, List<Product> products)
        {
            foreach(var prod in products)
            {
                
                _context.Set<Pharmacy>().FirstOrDefault(p => p.Id == pharmacyId)!.Products.Add(prod);
            }
        }
        public async Task<IEnumerable<Product?>> GetAllProductsAsync(ProductParamters paramters, bool trackChanges)
         => await FindAll(trackChanges)
            .SearchProducts(paramters.SearchTerm!)
            .Skip((paramters.PageNumber - 1) * paramters.PageSize)
            .Take(paramters.PageSize)
            .ToListAsync();
        public void DeleteProduct(Product product) => Delete(product);
        public async Task<Product?> GetProductByIdAsync(int productId, bool trackChanges)
            => await FindByCondition(p => p.ID.Equals(productId), trackChanges)
               .FirstOrDefaultAsync();
        public async Task<IEnumerable<Product>> GetPharmacyProducts(string pharmacyId)
            => await FindByCondition(p => 
            p.Pharmacies
            .FirstOrDefault(p => p.Id.Equals(pharmacyId))!.Id==pharmacyId 
            , trackChanges:false).ToListAsync();
    }
}
