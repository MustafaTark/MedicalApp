﻿// <auto-generated />
using System;
using MedicalApp_DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230406151817_CategoryMigration")]
    partial class CategoryMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Appointment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("PatiantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("ClinicId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PatientId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.ClinicDayes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Day")
                        .HasColumnType("int")
                        .HasColumnName("Day");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("ClinicId");

                    b.ToTable("ClinicDayes");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.ClinicMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("ClinicId");

                    b.ToTable("ClinicMessages");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmacyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quntity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.PatientMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientMessages");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("ReportID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ReportID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Rate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Number")
                        .HasMaxLength(5)
                        .HasColumnType("tinyint");

                    b.Property<string>("PatiantId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClinicId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Report", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a57dea48-c60b-4e85-8705-a2a07c53b537",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        },
                        new
                        {
                            Id = "d5b602ff-8c8e-41c0-96e0-e9280711067d",
                            Name = "Clinic",
                            NormalizedName = "CLINIC"
                        },
                        new
                        {
                            Id = "71ed2a65-e719-4524-9d76-aa97e507532c",
                            Name = "Pharmacy",
                            NormalizedName = "PHARMACY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PharmacyProduct", b =>
                {
                    b.Property<string>("PharmaciesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.HasKey("PharmaciesId", "ProductsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("PharmacyProduct");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Clinic", b =>
                {
                    b.HasBaseType("MedicalApp_DataLayer.Models.User");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TxnNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DoctorName");

                    b.HasIndex("Name");

                    b.HasIndex("TxnNumber")
                        .IsUnique()
                        .HasFilter("[TxnNumber] IS NOT NULL");

                    b.ToTable("Clinics", (string)null);
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Patient", b =>
                {
                    b.HasBaseType("MedicalApp_DataLayer.Models.User");

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Pharmacy", b =>
                {
                    b.HasBaseType("MedicalApp_DataLayer.Models.User");

                    b.Property<string>("TxnNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("TxnNumber")
                        .IsUnique()
                        .HasFilter("[TxnNumber] IS NOT NULL");

                    b.ToTable("Pharmacies", (string)null);
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Chat", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Clinic", "ClinicObj")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicalApp_DataLayer.Models.Patient", "PatientObj")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("ClinicObj");

                    b.Navigation("PatientObj");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.ClinicDayes", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Clinic", "ClinicObject")
                        .WithMany("Dayes")
                        .HasForeignKey("ClinicId");

                    b.Navigation("ClinicObject");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.ClinicMessage", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Chat", null)
                        .WithMany("ClinicMessages")
                        .HasForeignKey("ChatId");

                    b.HasOne("MedicalApp_DataLayer.Models.Clinic", "ClinicObject")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.Navigation("ClinicObject");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Order", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Pharmacy", null)
                        .WithMany("Orders")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.OrderItem", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.PatientMessage", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Chat", null)
                        .WithMany("PatientMessages")
                        .HasForeignKey("ChatId");

                    b.HasOne("MedicalApp_DataLayer.Models.Patient", "PatientObject")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("PatientObject");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Product", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Report", null)
                        .WithMany("Products")
                        .HasForeignKey("ReportID");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Report", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Appointment", "AppointmentObject")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalApp_DataLayer.Models.Clinic", "ClinicObject")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicalApp_DataLayer.Models.Patient", "PatientObject")
                        .WithMany("Reports")
                        .HasForeignKey("PatientId");

                    b.Navigation("AppointmentObject");

                    b.Navigation("ClinicObject");

                    b.Navigation("PatientObject");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.User", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.City", "CityObj")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("CityObj");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyProduct", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Pharmacy", null)
                        .WithMany()
                        .HasForeignKey("PharmaciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalApp_DataLayer.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Clinic", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.Category", "CategoryObj")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithOne()
                        .HasForeignKey("MedicalApp_DataLayer.Models.Clinic", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryObj");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Patient", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithOne()
                        .HasForeignKey("MedicalApp_DataLayer.Models.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Pharmacy", b =>
                {
                    b.HasOne("MedicalApp_DataLayer.Models.User", null)
                        .WithOne()
                        .HasForeignKey("MedicalApp_DataLayer.Models.Pharmacy", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Chat", b =>
                {
                    b.Navigation("ClinicMessages");

                    b.Navigation("PatientMessages");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Report", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Clinic", b =>
                {
                    b.Navigation("Dayes");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Patient", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("MedicalApp_DataLayer.Models.Pharmacy", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
