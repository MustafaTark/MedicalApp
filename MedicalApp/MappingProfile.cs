using AutoMapper;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<ClinicForRegisterDto, Clinic>().ReverseMap();
            
            CreateMap<PatientForRegisterDto, Patient>();
            CreateMap<PharmacyForRegisterDto, Pharmacy>();
            CreateMap<UserForLoginDto, User>();
            CreateMap<Appointment, AppointmentDto>().ForMember(c => c.Time,
                opt => opt.MapFrom(x => x.Time.ToString()));
            CreateMap<Clinic, ClinicDto>();
            CreateMap<ClinicForUpdateDto, Clinic>().ReverseMap();
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientForUpdateDto, Patient>();

            CreateMap<AppointmentForCreateDto, Appointment>().ForMember(a => a.Time,
                opt => opt.MapFrom(x => TimeSpan.Parse(x.Time!)));
            CreateMap<ClinicDayForCreateDto, ClinicDayes>().ForMember(a => a.Start,
                opt => opt.MapFrom(x => TimeSpan.Parse(x.Start!))).ForMember(a=>a.End,
                opt=> opt.MapFrom(x => TimeSpan.Parse(x.End!)));
            CreateMap<ClinicDayForUpdateDto, ClinicDayes>().ForMember(a => a.Start,
                opt => opt.MapFrom(x => TimeSpan.Parse(x.Start!))).ForMember(a => a.End,
                opt => opt.MapFrom(x => TimeSpan.Parse(x.End!)));
            CreateMap<ClinicDayes, ClinicDayDto>().ForMember(c => c.Start, opt => opt.MapFrom(x => x.Start.ToString()))
                .ForMember(c => c.End, opt => opt.MapFrom(x => x.End.ToString()));

            CreateMap<Rate, RateDto>().ReverseMap();
            CreateMap<RateForCreateDto, Rate>();

            CreateMap<PatientMessageForCreationDto, PatientMessage>();
            CreateMap<ClinicMessageForCreationDto, ClinicMessage>();
            CreateMap<ClinicMessage, MessageDto>().ReverseMap();
            CreateMap<PatientMessage, MessageDto>().ReverseMap();

            CreateMap<ChatForCreateDto, Chat>();    
         

            CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
            CreateMap<PharmacyForUpdateDto, Pharmacy>();
            CreateMap<ProductForCreateDto, Product>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderForCreateDto, Order>();
            CreateMap<OrderItemForCreateDto, OrderItem>();

            CreateMap<ReportForCreateDto, Report>();
            CreateMap<Report, ReportDto>();

            CreateMap<City, CityDto>();
            CreateMap<Chat, ChatDto>();

            CreateMap<AdminForRegisterDto, User>();
        }
    }
}
