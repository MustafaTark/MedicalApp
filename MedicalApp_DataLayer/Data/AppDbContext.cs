using MedicalApp_DataLayer.Configrations;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Data
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClinicDayes> ClinicDayes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
           
            base.OnModelCreating(builder);
            

            builder.Entity<User>().UseTptMappingStrategy().ToTable("Users");
            builder.Entity<Patient>()
                .ToTable("Patients").HasBaseType<User>();
            //builder.Entity<User>().ToTable("Patients");
            builder.Entity<Clinic>()
                .ToTable("Clinics").HasBaseType<User>();
            //builder.Entity<User>().ToTable("Clinics");
            builder.Entity<Pharmacy>()
                .ToTable("Pharmacies").HasBaseType<User>();
            //builder.Entity<User>().ToTable("Pharmacies");
            builder.Entity<Clinic>().HasIndex(c => c.TxnNumber).IsUnique();
            builder.Entity<Pharmacy>().HasIndex(p => p.TxnNumber).IsUnique();
            builder.Entity<Pharmacy>().HasMany(p => p.Products).WithMany(p => p.Pharmacies);

        }
    }
}
