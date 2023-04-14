﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Dto
{
    public class PharmacyDto
    {
        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public CityDto? City { get; set; }
        public string? Region { get; set; }
    }
}
