﻿using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
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
    public class AdminRepository : RepositoryBase<User> , IAdminRepository
    {
        private readonly IFilesManager _filesManager;
        public AdminRepository(AppDbContext context , IFilesManager filesManager) :base(context)
        {
           _filesManager= filesManager;
        }

        public int GetClinicsCount(bool trackChanges) => _context.Clinics.Count();

        public int GetPatientsCount(bool trackChanges) => _context.Patients.Count();

        public int GetPharmaciesCount(bool trackChanges) => _context.Pharmacies.Count();
        public void CreateCategory(Category category) => _context.Categories.Add(category);
        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges)
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
