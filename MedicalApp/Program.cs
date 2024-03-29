
using MedicalApp.Extentions;
using MedicalApp.Hubs;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Repositories;
using MedicalApp_BusinessLayer.Services;
//using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_DataLayer.Data;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
               policy =>
               {
                   //policy.WithOrigins("https://64be5a29d2bf0603b25edc62--enchanting-semifreddo-5ca30c.netlify.app/",
                   policy.SetIsOriginAllowed(origin => true)
                   //    "http://localhost:3000/")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
               });
});
builder.Services.ConfigureLifeTime();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity<User>();
builder.Services.ConfigureIdentity<Clinic>();
builder.Services.ConfigureIdentity<Patient>();
builder.Services.ConfigureIdentity<Pharmacy>();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddSignalR();
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config.xml"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(
  opt=>
      opt.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//ILoggerManager logger = new LoggerManager();
//app.ConfigureExceptionHandler(logger);
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("hubs/chat");
});
//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
