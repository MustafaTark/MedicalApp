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
        public DbSet<City> Cities { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClinicMessage> ClinicMessages { get; set; }
        public DbSet<PatientMessage> PatientMessages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
           
            base.OnModelCreating(builder);
          builder.ApplyConfiguration(new RoleConfigrations());
            builder.AddInhertanceTaples();
            builder.AddIndexes();
            builder.AddManyToManyTaples();
           builder.AddOneToManyRelationship();

        }
    }
}
