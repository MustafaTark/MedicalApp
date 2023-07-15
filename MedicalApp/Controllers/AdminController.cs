using AutoMapper;
using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_BusinessLayer.Dto;
using MedicalApp_BusinessLayer.Services;
using MedicalApp_DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //private readonly ILoggerManager _logger;
        //private readonly IMapper _mapper;
        //private readonly UserManager<User> _userAdminManager;
        //private readonly IAuthenticationManager _authManager;
        //private IRepositoryManager _repository;
        //public AdminController(
        //    ILoggerManager logger,
        //    IMapper mapper,
        //    UserManager<User> userAdminManager,
        //    IAuthenticationManager authManager,
        //    IRepositoryManager repository)
        //{
        //    _logger = logger;
        //    _mapper = mapper;
        //    _userAdminManager = userAdminManager;
        //    _authManager = authManager;
        //    _repository = repository;
        //}

        //[HttpPost("Registration")]
        //public async Task<IActionResult> RegisterUser([FromBody] AdminForRegisterDto userForRegistration)
        //{
        //    var user = _mapper.Map<User>(userForRegistration);
        //    var result = await _userAdminManager.CreateAsync(user, userForRegistration.Password!);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    await _userAdminManager.AddToRoleAsync(user, "Admin");
        //    return StatusCode(201);
        //}
        //[HttpPost("Login")]

        //public async Task<IActionResult> Authenticate([FromBody] UserForLoginDto user)
        //{
        //    if (!await _authManager.ValidateUser(user))
        //    {
        //        _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
        //        return Unauthorized();
        //    }
            
        
        //    var patient = await _userAdminManager.FindByNameAsync(user.UserName!);
        //    var useradmin =await  _userAdminManager.IsInRoleAsync(patient!,"Admin");
        //    if(!useradmin)
        //        return NotFound();
        //    return Ok(
        //    new
        //    {
        //        Token = await _authManager.CreateToken(),
        //         UserId = await _userAdminManager.GetUserIdAsync(patient!)
        //    }
        //    );
        //}
        //[HttpGet("Patients")]
        //public IActionResult GetPatientsCount()
        //{
        //    var patientsCount = _repository.Admin.GetPatientsCount(trackChanges: false);
        //    if (patientsCount == 0)
        //    {
        //        return NotFound("There are no patients in the system yet");
        //    }
        //    return Ok(patientsCount);
        //}
        //[HttpGet("Clinics")]
        //public IActionResult GetClinicsCount()
        //{
        //    var clinicsCount = _repository.Admin.GetClinicsCount(trackChanges: false);
        //    if (clinicsCount == 0)
        //    {
        //        return NotFound("There are no Clinics in the system yet");
        //    }
        //    return Ok(clinicsCount);
        //}
        //[HttpGet("Pharmacies")]
        //public IActionResult GetPharmaciesCount()
        //{
        //    var pharmaciesCount = _repository.Admin.GetPharmaciesCount(trackChanges: false);
        //    if (pharmaciesCount == 0)
        //    {
        //        return NotFound("There are no patients in the system yet");
        //    }
        //    return Ok(pharmaciesCount);
        //}
        //[HttpPost("Products")]
        //public async Task<IActionResult> AddProduct([FromBody] ProductForCreateDto productDto)
        //{
        //    if (productDto == null)
        //    {
        //        _logger.LogError("ProductForCreateDto object sent from client is null");
        //        return BadRequest("ProductForCreateDto object sent from client is null");
        //    }
        //    try { 
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    _repository.Product.CreateProduct(productEntity);
        //    await _repository.SaveChanges();
        //    var productToReturn = _mapper.Map<ProductDto>(productEntity);
        //    return Ok(productToReturn);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
        //        {
        //            return Conflict(new { message = "A Product with the same name already exists." });
        //        }
        //        else
        //        {
        //            return StatusCode(400, new { message = "An error occurred while creating the topic." });
        //        }
        //    }
        //}
        //[HttpPost("Category")]
        //public async Task<IActionResult> AddCategory([FromBody] CategoryForCreateDto categoryDto)
        //{
        //    if (categoryDto == null)
        //    {
        //        _logger.LogError("CategoryForCreateDto object sent from client is null");
        //        return BadRequest("CategoryForCreateDto object sent from client is null");
        //    }
        //    try
        //    {
        //        var categoryEntity = _mapper.Map<Category>(categoryDto);
        //        _repository.Admin.CreateCategory(categoryEntity);
        //        await _repository.SaveChanges();
        //        var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
        //        return Ok(categoryToReturn);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
        //        {
        //            return Conflict(new { message = "A Category with the same name already exists." });
        //        }
        //        else
        //        {
        //            return StatusCode(400, new { message = "An error occurred while creating the topic." });
        //        }
        //    }
        //}
        //[HttpGet("Categories")]
        //public async Task<IActionResult> GetAllCategories()
        //{
        //    var categories = await _repository.Admin.GetAllCategories(trackChanges: false);
        //    if(categories == null)
        //    {
        //        _logger.LogInfo("There are no categories inserted in the database yet");
        //        return NotFound("There are no categories inserted in the database yet");
        //    }
        //    var categoryEntities = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        //    return Ok(categoryEntities);
        //}
    }
}
