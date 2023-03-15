using AutoMapper;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.RequestFeatures;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class ClinicController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Clinic> _userClinicManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IRepositoryManager _repository;
       
        public ClinicController(
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Clinic> userClinicManager,
            IAuthenticationManager authManager,
            IRepositoryManager repository
                       
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userClinicManager = userClinicManager;
            _authManager = authManager;
            _repository = repository;
          
           
        }
        [HttpPost]

        public async Task<IActionResult> RegisterUser([FromBody] ClinicForRegisterDto userForRegistration)
        {
            var user = _mapper.Map<Clinic>(userForRegistration);
            var result = await _userClinicManager.CreateAsync(user, userForRegistration.Password!);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userClinicManager.AddToRolesAsync(user, userForRegistration.Roles!);
            return StatusCode(201);
        }
        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] UserForLoginDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Clinic user name or password.");
                return Unauthorized();
            }
         var clinic=await _userClinicManager.FindByNameAsync(user.UserName!);
            return Ok(
            new
            {
                Token = await _authManager.CreateToken(),
               UserId=await _userClinicManager.GetUserIdAsync(clinic!)
            }
            );
        }
        //[HttpGet("GetUserId")]
        //public Task<IActionResult> GetUserId(string userId)
        //{
        //    var user = HttpContext.User;
        //    var userId=
        //    return Ok()
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllClinics([FromQuery] ClinicParamters paramters)
        {
            var clinics = await _repository.Clinic.GetAllClinics(paramters);
            var clinicsDto = _mapper.Map<IEnumerable<ClinicDto>>(clinics);
            return Ok(clinicsDto);
        }
        [HttpGet("Appointment")]
        public async Task<IActionResult> GetAllAppointments(string clinicId)
        {
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var appointments = await _repository.Appointment.GetAllAppointmentsToClinicAsync(clinicId);
            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return Ok(appointmentsDto);
        }
        [HttpGet("GetClinic")]
        public async Task<IActionResult> GetClinic(string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var clinicDto = _mapper.Map<ClinicDto>(clinic);
            return Ok(clinicDto);
        }
        [HttpDelete("{clinicId}")]
        public async Task<IActionResult> DeleteClinic(string clinicId)
        {
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Clinic.DeleteClinic(clinic);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpPost("ClinicDays")]
        public async Task<IActionResult> AddClinicDayes(string clinicId,
            [FromBody] List<ClinicDayForCreateDto> dayesDto)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var dayes = _mapper.Map<List<ClinicDayes>>(dayesDto);
            _repository.ClinicDays.Create(dayes);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("ClinicDayes")]
        public async Task<IActionResult> GetClinicDay(int clinicDayId)
        {
            if (clinicDayId.ToString().IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinicDay = await _repository.ClinicDays.GetClinicDay(clinicDayId);
            if (clinicDay is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicDayId} doesn't exist in the database.");
                return NotFound();
            }
            var clinicDayDto = _mapper.Map<ClinicDayDto>(clinicDay);
            return Ok(clinicDayDto);

        }
        [HttpDelete("ClinicDayes")]
        public async Task<IActionResult> DeleteClinicDay(int dayId)
        {
            if (dayId.ToString().IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinicDay = await _repository.ClinicDays.GetClinicDay(dayId);
            if (clinicDay is null)
            {
                _logger.LogInfo($"Clinic with id: {dayId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.ClinicDays.DeleteClinicDay(clinicDay);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("Rates")]
        public async Task<IActionResult> GetRates(string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var rates = await _repository.RateRepository.GetRatesForClinic(clinicId);
            var ratesDto = _mapper.Map<IEnumerable<RateDto>>(rates);
            return Ok(ratesDto);
        }
        [HttpPost("Upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file, string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            try
            {
                if (file.Length > 0)
                {
                    _repository.Clinic.UploadImage(file, clinicId);

                    await _repository.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var fileStream = _repository.Clinic.GetImage(clinicId);
            return new FileStreamResult(fileStream, "image/png");
        }
        [HttpPost("Report")]
        public async Task<IActionResult> CreateReport([FromBody] ReportForCreateDto reportForCreateDto)
        {
            var patient = _repository.Patient.GetPatientByIdAsync(reportForCreateDto.PatientId!);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with ID: {reportForCreateDto.PatientId} doesn't exist in the Database");
                return NotFound();
            }
            var clinic = _repository.Clinic.GetClinicById(reportForCreateDto.ClinicId!);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with ID: {reportForCreateDto.ClinicId} doesn't exist in the Database");
                return NotFound();
            }
            var appointment = _repository.Appointment.GetAppointmentByIdAsync(reportForCreateDto.AppointmentId);
            if (appointment is null)
            {
                _logger.LogInfo($"Appointment with ID: {reportForCreateDto.AppointmentId} doesn't exist in the Database");
                return NotFound();
            }
            var report = _mapper.Map<Report>(reportForCreateDto);
            _repository.Report.CreateReport(report);
            await _repository.SaveChanges();
            //var reportToReturn = _mapper.Map<ReportDto>(report);
            return NoContent();
        }
        [HttpGet("Reports")]
        public async Task<IActionResult> GetAllReportsForClinic(string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");

            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic With ID: {clinicId} doesn't exist in the database");
                return NotFound();
            }
            var report = await _repository.Report.GetAllReportsForClinic(clinicId, trackChanges: false);
            var reportDto = _mapper.Map<IEnumerable<ReportDto>>(report);
            return Ok(reportDto);
        }
        [HttpGet("reportIdreportId")]
        public async Task<IActionResult> GetReport(Guid reportId)
        {
            if (reportId.ToString().IsNullOrEmpty())
            {
                _logger.LogInfo($"Report with ID: {reportId} is null");
                return BadRequest();
            }
            var report = await _repository.Report.GetReportById(reportId, trackChanges: false);
            if (report is null)
            {
                _logger.LogInfo($"Report with ID: {reportId} doesn't exist in the database.");
                return NotFound();
            }
            var reportDto = _mapper.Map<ReportDto>(report);
            return Ok(reportDto);
        }
        [HttpDelete("reportId")]
        public async Task<IActionResult> DeleteReport(Guid reportId)
        {
            if (reportId.ToString().IsNullOrEmpty())
            {
                _logger.LogInfo($"Report with ID: {reportId} is null");
                return BadRequest();
            }
            var report = await _repository.Report.GetReportById(reportId, trackChanges: false);
            if (report is null)
            {
                _logger.LogInfo($"Report with ID: {reportId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Report.DeleteReport(report);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpPut("clinicId")]
        public async Task<IActionResult> UpdateClinic(string clinicId,[FromBody] ClinicForUpdateDto clinicDto)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");

            }
            var clinicDb = await _repository.Clinic.GetClinicById(clinicId);
            if (clinicDb is null)
            {
                _logger.LogInfo($"Clinic With ID: {clinicId} doesn't exist in the database");
                return NotFound();
            }
            if (clinicDto is null)
            {
                _logger.LogInfo($"ModelState Is not Valid {ModelState}");
                return BadRequest(ModelState);
            }
            _mapper.Map(clinicDb,clinicDto);
          
           await _repository.SaveChanges();
            return NoContent();
        }


    }
}
