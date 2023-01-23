using AutoMapper;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PharmacyController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Pharmacy> _userPharmacyManager;
        private readonly IAuthenticationManager _authManager;
        public PharmacyController(
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Pharmacy> userPharmacyManager,
            IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userPharmacyManager = userPharmacyManager;
            _authManager = authManager;
        }
        [HttpPost]

        public async Task<IActionResult> RegisterUser([FromBody] PharmacyForRegisterDto userForRegistration)
        {
            var user = _mapper.Map<Pharmacy>(userForRegistration);
            var result = await _userPharmacyManager.CreateAsync(user, userForRegistration.Password!);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userPharmacyManager.AddToRolesAsync(user, userForRegistration.Roles!);
            return StatusCode(201);
        }
        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] UserForLoginDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }
            return Ok(
            new
            {
                Token = await _authManager.CreateToken()
            }
            );
        }
    }
}
