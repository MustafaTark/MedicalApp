using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IProductRepository
    {
       

        void AddProductsToPharmacy(string pharmacyId, List<Product> product);
        Task<IEnumerable<Product?>> GetAllProductsAsync(ProductParamters paramters, bool trackChanges);
        Task<Product?> GetProductByIdAsync(int productId, bool trackChanges);
        void DeleteProduct(string pharmacyId, int productId);
        Task<IEnumerable<Product>> GetPharmacyProducts(ProductParamters paramters, string pharmacyId);
        void UploadImage(IFormFile file, int productId);
        FileStream GetImage(int productId);
        Task<Product?> GetProdcutForPharmacy(string pharmacyId, int productId);


    }
}
