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
            this IQueryable<Clinic> clinics,string searchTerm,string category,string city)
        {
            var clinicsReturned = clinics;
            if (!string.IsNullOrWhiteSpace(category))
            {
                var lowerCaseTerm = category.Trim().ToLower();
                clinicsReturned = clinicsReturned.Where(e => e.Category!.ToLower().Contains(lowerCaseTerm));
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                var lowerCaseTerm = city.Trim().ToLower();
                clinicsReturned = clinicsReturned.Where(e => e.City!.ToLower().Contains(lowerCaseTerm));
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerCaseTerm = searchTerm.Trim().ToLower();
                clinicsReturned = clinicsReturned.Where(e => e.Name!.ToLower().Contains(lowerCaseTerm)
            || e.DoctorName.ToLower().Contains(searchTerm));
            }
            

            return clinicsReturned;

        }
        //public static IQueryable<Clinic> FilterByCategory(
        //    this IQueryable<Clinic> clinics, string category)
        //{
        //    if (string.IsNullOrWhiteSpace(category))
        //        return clinics;
        //    var lowerCaseTerm = category.Trim().ToLower();
        //    return clinics.Where(e => e.Category!.ToLower().Contains(lowerCaseTerm));
        //}
        //public static IQueryable<Clinic> FilterByCity(
        //   this IQueryable<Clinic> clinics, string city)
        //{
        //    if (string.IsNullOrWhiteSpace(city))
        //        return clinics;
        //    var lowerCaseTerm = city.Trim().ToLower();
        //    return clinics.Where(e => e.City!.ToLower().Contains(lowerCaseTerm));
        //}

    }
}
