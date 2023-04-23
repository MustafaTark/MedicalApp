﻿using MedicalApp_DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Configrations
{
    public static class ExtentionModelBuilder
    {
        public static void AddIndexes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                   .HasIndex(r => r.ClinicId);
            modelBuilder.Entity<Clinic>().HasIndex(c => c.TxnNumber).IsUnique();
            modelBuilder.Entity<Clinic>().HasIndex(c => c.CategoryId);
            modelBuilder.Entity<Clinic>().HasIndex(c => c.CityId);
            modelBuilder.Entity<Clinic>().HasIndex(c => c.DoctorName);
            modelBuilder.Entity<Clinic>().HasIndex(c => c.Name);
            modelBuilder.Entity<Pharmacy>().HasIndex(p => p.TxnNumber).IsUnique();
        }
        public static void AddInhertanceTaples(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy().ToTable("Users");
            modelBuilder.Entity<Patient>()
                .ToTable("Patients").HasBaseType<User>();

            modelBuilder.Entity<Clinic>()
                .ToTable("Clinics").HasBaseType<User>();

            modelBuilder.Entity<Pharmacy>()
                .ToTable("Pharmacies").HasBaseType<User>();
            
        }
        public static void AddManyToManyTaples(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasMany(p => p.Products).WithMany(p => p.Pharmacies);
           
        }
        public static void AddOneToManyRelationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
        .HasOne(c => c.Pharmacy)
        .WithMany(o => o.Orders)
        .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Order>()
                .HasOne(o=>o.PatientObj)
        .WithMany(c => c.Orders)
        .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Report>()
      .HasOne(c => c.PatientObject)
      .WithMany(o => o.Reports)
      .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
     .HasOne(c => c.PatientObj)
     .WithMany(o => o.Appointments)
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Chat>()
     .HasOne(c => c.PatientObj)
     .WithMany(o => o.Chats)
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PatientMessage>()
    .HasOne(c => c.PatientObject)
    .WithMany(o => o.PatientMessages)
    .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ClinicMessage>()
    .HasOne(c => c.ClinicObject)
    .WithMany(o => o.ClinicMessages)
    .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Rate>()
         .HasOne(c => c.PatientObj)
         .WithMany(o => o.Rates)
         .OnDelete(DeleteBehavior.ClientCascade);



            modelBuilder.Entity<Report>()
     .HasOne(c => c.ClinicObject)
     .WithMany(o => o.Reports)
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ClinicDayes>()
     .HasOne(c => c.ClinicObject)
     .WithMany(o => o.Dayes)
    
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Appointment>()
        .HasOne(c => c.ClinicObj)
        .WithMany(o => o.Appointments)
        
        .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Chat>()
     .HasOne(c => c.ClinicObj)
     .WithMany(o => o.Chats)
     
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Rate>()
                .HasOne(c => c.ClinicObj)
                .WithMany(o => o.Rates)
                
         .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.OrderObj)
        .WithMany(c => c.Items)
       
        .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
