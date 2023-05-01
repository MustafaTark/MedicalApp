using AutoMapper;
using MedicalApp.Hubs;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub, IChatClient> _messageHub;
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;
        public ChatController(
            IHubContext<ChatHub, IChatClient> messageHub,
            IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper
            )
        {
            _messageHub = messageHub;
          _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost("Chat")]
        public async Task<IActionResult> PostChat(ChatForCreateDto chatDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo("message not availble because : " + ModelState.ToString()!);
                return BadRequest(ModelState);
            }
            var chatEntity = await _repository.Chat.GetChatToPatientAndClinic(chatDto.PatientId!,chatDto.ClinicId!);
            if (chatEntity is not null)
            {
                return BadRequest("Chat already created");
            }
            var chat =_mapper.Map<Chat>(chatDto);
            _repository.Chat.CreateChat(chat);
            await _repository.SaveChanges();
         
            return NoContent();
        }
        [HttpGet("PatientMessages")]
        public async Task<IActionResult> GetPatientMessages(Guid chatId)
        {
            if (string.IsNullOrEmpty(chatId.ToString()))
            {
                _logger.LogInfo("ChatId Is Null");
                return BadRequest();
            }
            var chat = await _repository.Chat.GetChatByIdAsync(chatId);
            if(chat == null)
            {
                _logger.LogInfo($"Chat with id {chatId} Not Found");
                return NotFound();
            }
            var patientMessages = await _repository.PatientMessage.GetPatientMessages(chatId);
            var patientMessageDto = _mapper.Map<IEnumerable<MessageDto>>(patientMessages);
            return Ok(patientMessageDto);
        }
        [HttpGet("ClinicMessages")]
        public async Task<IActionResult> GetClinicMessages(Guid chatId)
        {
            if (string.IsNullOrEmpty(chatId.ToString()))
            {
                _logger.LogInfo("ChatId Is Null");
                return BadRequest();
            }
            var chat = await _repository.Chat.GetChatByIdAsync(chatId);
            if(chat == null)
            {
                _logger.LogInfo($"Chat with id {chatId} Not Found");
                return NotFound();
            }
            var ClinicMessages = await _repository.ClinicMessage.GetClinicMessages(chatId);
            var ClinicMessagesDto = _mapper.Map<IEnumerable<MessageDto>>(ClinicMessages);
            return Ok(ClinicMessagesDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetChat(string patientId, string clinicId)
        {
            if (clinicId.IsNullOrEmpty())
            {
                _logger.LogInfo("Clinic Id is null");
                return BadRequest("Clinic Id is null");
            }
            if (patientId.IsNullOrEmpty())
            {
                _logger.LogInfo("Patient Id is null");
                return BadRequest("Patient Id is null");
            }
            var chat =await _repository.Chat.GetChatToPatientAndClinic(patientId, clinicId);
            return Ok(
                new
                {
                    ChatId= chat.Id,
                }
                );
        }
        [HttpGet("ClinicChats")]
        public async Task<IActionResult> GetClinicChats(string clinicId)
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
            var chats = await _repository.Chat.GetAllToClinic(clinicId);
            var chatsDto=_mapper.Map<IEnumerable<ChatDto>>(chats);
            return Ok(chatsDto);
        }
        [HttpGet("PatientChats")]
        public async Task<IActionResult> GetPatientChats(string patientId)
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
            var chats = await _repository.Chat.GetAllToPatient(patientId);
            var chatsDto = _mapper.Map<IEnumerable<ChatDto>>(chats);
            return Ok(chatsDto);
        }
        [HttpPost("PatientMessages")]
        public async Task<IActionResult> PostPatientMessage([FromBody]PatientMessageForCreationDto patientMessageDto)
        {
           if(!ModelState.IsValid)
            {
               _logger.LogInfo("message not availble because : "+ModelState.ToString()!);
                return BadRequest(ModelState);
            }
            var patientMessage = _mapper.Map<PatientMessage>(patientMessageDto);
            var message = new MessageDto
            {
                Date= patientMessage.Date,
                Message = patientMessage.Message,
                Role = "Patient"
            };
            
            _repository.PatientMessage.CreateMessage(patientMessage);
           await  _repository.SaveChanges();
            await _messageHub.Clients.All.ReceiveMessage(message);
            return Ok(message);
        }
        [HttpPost("ClinicMessages")]
        public async Task<IActionResult> PostClinicMessage(ClinicMessageForCreationDto clinicMessageDto)
        {
           if(!ModelState.IsValid)
            {
               _logger.LogError("message not availble because : "+ModelState.ToString()!);
                return BadRequest(ModelState);
            }
            var clinicMessage = _mapper.Map<ClinicMessage>(clinicMessageDto);
            var message = new MessageDto
            {
                Date = clinicMessageDto.Date,
                Message = clinicMessageDto.Message,
                Role = "Clinic"
            };
            _repository.ClinicMessage.CreateMessage(clinicMessage);
            await _repository.SaveChanges();
            await _messageHub.Clients.All.ReceiveMessage(message);
            return Ok(message);
        }
    }
}
