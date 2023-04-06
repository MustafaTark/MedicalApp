using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.ExtentionsRepo
{
    public static class ClinicRepositoryExtention
    {
        public static IQueryable<Clinic> Search(
            this IQueryable<Clinic> clinics,string searchTerm,int category,int city)
        {
            var clinicsReturned = clinics;
            if (category is not 0)
            {
            
                clinicsReturned = clinicsReturned.Where(e => e.CategoryId!.Equals(category));
            }
            if (city is not 0)
            {
                
                clinicsReturned = clinicsReturned.Where(e => e.CityId!.Equals(city));
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerCaseTerm = searchTerm.Trim().ToLower();
                clinicsReturned = clinicsReturned.Where(e => e.Name!.Contains(lowerCaseTerm)
            || e.DoctorName.ToLower().Contains(searchTerm));
            }
            

            return clinicsReturned;

        }

    }
}
