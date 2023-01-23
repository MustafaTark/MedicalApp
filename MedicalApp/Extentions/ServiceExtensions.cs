using MedicalApp_DataLayer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Identity.Web;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Repositories;

namespace MedicalApp.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<AppDbContext>(
                    opts =>
                    {
                        opts.UseSqlServer(connectionString 
                           , b => b.MigrationsAssembly("MedicalApp")
                            );

                });

        }
        public static void ConfigureIdentity<T>(this IServiceCollection services) where T : User
        {
            var authBuilder = services.AddIdentityCore<T>
                (o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 10;
                    o.User.RequireUniqueEmail = true;
                });
            authBuilder = new IdentityBuilder(authBuilder.UserType, typeof(IdentityRole), services);
            authBuilder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("validAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                    };
                })
                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"), "jwtBearerScheme2");

        }
        public static void ConfigureLifeTime(this IServiceCollection services)
        {
            services.AddScoped<User, Clinic>();
            services.AddScoped<User, Pharmacy>();
           services.AddScoped<User, Patient>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IFilesManager, FilesManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<RepositoryBase<Clinic>, ClinicRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<RepositoryBase<Patient>, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<RepositoryBase<Appointment>, AppointmentRepository>();
            services.AddScoped<IClinicDaysRepository, ClinicDayRepository>();
            services.AddScoped<RepositoryBase<ClinicDayes>, ClinicDayRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<RepositoryBase<Rate>, RateRepository>();

        }
       
    }
}
