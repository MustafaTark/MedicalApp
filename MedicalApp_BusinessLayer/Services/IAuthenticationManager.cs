using MedicalApp_BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Services
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForLoginDto userForAuth);
        Task<string> CreateToken();
    }
}
