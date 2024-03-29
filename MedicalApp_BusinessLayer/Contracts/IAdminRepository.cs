﻿using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IAdminRepository
    {
        int GetPatientsCount(bool trackChanges);
        int GetClinicsCount(bool trackChanges);
        int GetPharmaciesCount(bool trackChanges);
        void CreateCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);
    }
}
