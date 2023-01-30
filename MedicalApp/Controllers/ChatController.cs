using AutoMapper;
using MedicalApp.Hubs;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        [HttpPost("PatientMessages")]
        public async Task<IActionResult> PostPatientMessage(PatientMessageForCreationDto patientMessageDto)
        {
           if(!ModelState.IsValid)
            {
               _logger.LogInfo("message not availble because : "+ModelState.ToString()!);
                return BadRequest(ModelState);
            }
           var patient =await _repository.Patient.GetPatientByIdAsync(patientMessageDto.PatientId!);
            
            var patientMessage = _mapper.Map<PatientMessage>(patientMessageDto);
            var message = _mapper.Map<MessageDto>(patientMessage);
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
           var patient =await _repository.Clinic.GetClinicById(clinicMessageDto.ClinicId!);
          
            var clinicMessage = _mapper.Map<ClinicMessage>(clinicMessageDto);
            var message = _mapper.Map<MessageDto>(clinicMessage);
            _repository.ClinicMessage.CreateMessage(clinicMessage);
            await _repository.SaveChanges();
            await _messageHub.Clients.All.ReceiveMessage(message);
            return Ok(message);
        }
    }
}
