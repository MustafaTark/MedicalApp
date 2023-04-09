using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.ExtentionsRepo;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IFilesManager _filesManager;
        public ProductRepository(AppDbContext context,IFilesManager filesManager) : base(context)
        {
            _context = context;
            _filesManager = filesManager;
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
        public void DeleteProduct(string pharmacyId, int productId)
        {
            var product = _context.Pharmacies.Where(p => p.Id == pharmacyId).SingleOrDefault()!.Products.Where(o => o.ID == productId).FirstOrDefault();
            _context.Pharmacies.Where(p => p.Id == pharmacyId).SingleOrDefault()!.Products.Remove(product!);
        }
        public async Task<Product?> GetProductByIdAsync(int productId, bool trackChanges)
            => await FindByCondition(p => p.ID.Equals(productId), trackChanges)
               .FirstOrDefaultAsync();
        public async Task<IEnumerable<Product>> GetPharmacyProducts(string pharmacyId)
            => await FindByCondition(p => 
            p.Pharmacies
            .FirstOrDefault(p => p.Id.Equals(pharmacyId))!.Id==pharmacyId 
            , trackChanges:false).ToListAsync();

        public async Task<Product?> GetProdcutForPharmacy(string pharmacyId, int productId)
         => await FindByCondition(p => p.ID == productId && p.Pharmacies.FirstOrDefault(p=> p.Id == pharmacyId)!.Id == pharmacyId, trackChanges: true)
         .FirstOrDefaultAsync();

        public void UploadImage(IFormFile file, int productId)
        {
            string fileName = _filesManager.UploadFiles(file);
            FindByCondition(p => p.ID == productId, trackChanges: true)
              .FirstOrDefault()!.ImageUrl = fileName;
        }
        public FileStream GetImage(int productId)
        {
            var image = FindByCondition(c => c.ID == productId, trackChanges: true)
                .FirstOrDefault()!.ImageUrl;
            return _filesManager.GetFile(image!);
        }
    }
}
