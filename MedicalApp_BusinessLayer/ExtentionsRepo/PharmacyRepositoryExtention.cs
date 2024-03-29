﻿using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.ExtentionsRepo
{
    public static class PharmacyRepositoryExtention
    {
        public static IQueryable<Pharmacy> Search(
            this IQueryable<Pharmacy> pharmacies, string searchTerm, int city)
        {
            var pharmaciesReturned = pharmacies;
            if (city is not 0)
            {
                
                pharmaciesReturned = pharmaciesReturned.Where(e => e.CityId!.Equals(city));
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerCaseTerm = searchTerm.Trim().ToLower();
                pharmaciesReturned = pharmaciesReturned.Where(e => e.Name!.ToLower().Contains(lowerCaseTerm));
            }
            return pharmaciesReturned;

        }
        public static IQueryable<Product> SearchProducts(
            this IQueryable<Product> products, string searchTerm)
        {
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                
               return products;
            }
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(e => e.Name!.ToLower().Contains(lowerCaseTerm));

        }
    }
}
