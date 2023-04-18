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

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PatientController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Patient> _userPatientManager;
        private readonly IAuthenticationManager _authManager;
        private  IRepositoryManager _repository;
        public PatientController(
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Patient> userPatientManager,
            IAuthenticationManager authManager,
            IRepositoryManager repository)
        {
            _logger = logger;
            _mapper = mapper;
            _userPatientManager = userPatientManager;
            _authManager = authManager;
            _repository = repository;
        }
        [HttpPost]

        public async Task<IActionResult> RegisterUser([FromBody] PatientForRegisterDto userForRegistration)
        {
            var user = _mapper.Map<Patient>(userForRegistration);
            var result = await _userPatientManager.CreateAsync(user, userForRegistration.Password!);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userPatientManager.AddToRolesAsync(user, userForRegistration.Roles!);
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
            var patient = await _userPatientManager.FindByNameAsync(user.UserName!);
            return Ok(
            new
            {
                Token = await _authManager.CreateToken(),
                 UserId = await _userPatientManager.GetUserIdAsync(patient!)
            }
            );
        }
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatient(string patientId)
        {
            var patient=await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if(patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            var patientDto=_mapper.Map<PatientDto>(patient);
            return Ok(patientDto);
        }
        [HttpDelete("{patientId}")]
        public async Task<IActionResult> DeletePatient(string patientId)
        {
            var patient =await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Patient.DeletePatient(patient);
           await _repository.SaveChanges();
            return NoContent();
        }
        [HttpPost("Reserve")]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreateDto appointmentDto)
        {
            var patient = await  _repository.Patient.GetPatientByIdAsync(appointmentDto.PatiantId!, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {appointmentDto.PatiantId} doesn't exist in the database.");
                return NotFound();
            }
            var clinic = await  _repository.Clinic.GetClinicById(appointmentDto.ClinicId!, trackChanges: false);
            if(clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {appointmentDto.ClinicId} doesn't exist in the database.");
                return NotFound();
            }
           
             
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            _repository.Appointment.CreateAppointment(appointment);
           await _repository.SaveChanges();
            var appointmentToReturn=_mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentToReturn);
        }
        [HttpGet("AppointmentCheck")]
       public async Task<IActionResult> CheckAppointment([FromQuery] AppointmentParamters paramters)
        {
            var patient = await _repository.Patient.GetPatientByIdAsync(paramters.PatientId!, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {paramters.PatientId} doesn't exist in the database.");
                return NotFound();
            }
            var clinic = await _repository.Clinic.GetClinicById(paramters.ClinicId! , trackChanges: false);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {paramters.ClinicId} doesn't exist in the database.");
                return NotFound();
            }
            try
            {
              TimeSpan.Parse(paramters.Time!);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex);
            }
            var isavailable = await _repository.Appointment
                                                  .CheckAppointmentAvailability(paramters);
            
           return Ok(
              new
              {
                  IsAvailable= isavailable
              }
            ); 
           
        }
        [HttpGet("GetAppointment")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            if(id.ToString().IsNullOrEmpty())
            {
                _logger.LogInfo($" id is null");
                return BadRequest();
            }
            var appointment=await _repository.Appointment.GetAppointmentByIdAsync(id);
            if(appointment is null)
            {
                _logger.LogInfo($"Appointment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var appointmentDto=_mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }
        [HttpGet("Appointment")]
        public async Task<IActionResult> GetAllAppointments(string patientId)
        {
            var clinic = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: true);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            var appointments = await _repository.Appointment.GetAllAppointmentsToPatientAsync(patientId);
            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return Ok(appointmentsDto);
        }
        [HttpPost("Rates")]
        public async Task<IActionResult> AddRate(string clinicId, [FromBody] RateForCreateDto rateDto)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId, trackChanges: false);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            var rate = _mapper.Map<Rate>(rateDto);
            _repository.RateRepository.CreateRate(rate);
           await  _repository.SaveChanges();
            return NoContent();
        }
        [HttpPut("Rates")]
        public async Task<IActionResult> UpdateRate(string patientId, string clinicId,[FromBody] int newNumber)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId, trackChanges: false);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");
            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
           await _repository.RateRepository.UpdateRate(patientId,clinicId, newNumber);
           await _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("Rates")]
        public async Task<IActionResult> GetRateToPatient(string patientId,string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            var clinic = await _repository.Clinic.GetClinicById(clinicId, trackChanges: false);
            if (clinic is null)
            {
                _logger.LogInfo($"Clinic with id: {clinicId} doesn't exist in the database.");
                return NotFound();
            }
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");
            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            int number = await _repository.RateRepository.GetSingleRateToPatient(patientId, clinicId);
            return Ok(number);
        }
        [HttpPost("Upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file, string patientId)
        {
            
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");
            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            try
            {
                if (file.Length > 0)
                {
                    _repository.Patient.UploadImage(file, patientId);

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
        public async Task<IActionResult> GetImage(string patientId)
        {
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");
            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }
            var fileStream = _repository.Patient.GetImage(patientId);
            return new FileStreamResult(fileStream, "image/png");
        }
        [HttpGet("Reports")]
        public async Task<IActionResult> GetAllReportsForPatient(string patientId)
        {
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");

            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: false);
            if (patient is null)
            {
                _logger.LogInfo($"Patient With ID: {patientId} doesn't exist in the database");
                return NotFound();
            }
            var report = await _repository.Report.GetAllReportsForPatient(patientId, trackChanges: false);
            var reportDto = _mapper.Map<IEnumerable<ReportDto>>(report);
            return Ok(reportDto);
        }
        [HttpGet("reportId")]
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
        [HttpPut("patientId")]
        public async Task<IActionResult> UpdateClinic(string patientId, [FromBody] PatientForUpdateDto patientDto)
        {
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");

            }
            var patientDb = await _repository.Patient.GetPatientByIdAsync(patientId, trackChanges: true);
            if (patientDb is null)
            {
                _logger.LogInfo($"Patient With ID: {patientDb} doesn't exist in the database");
                return NotFound();
            }
            if (patientDto is null)
            {
                _logger.LogInfo($"ModelState Is not Valid {ModelState}");
                return BadRequest(ModelState);
            }
            _mapper.Map(patientDto, patientDb);

            await _repository.SaveChanges();
            return NoContent();
        }

    }
}
