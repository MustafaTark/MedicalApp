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
using System.Collections.Generic;

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
        private readonly IRepositoryManager _repository;
        public PharmacyController(
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Pharmacy> userPharmacyManager,
            IAuthenticationManager authManager,
            IRepositoryManager repository)
        {
            _logger = logger;
            _mapper = mapper;
            _userPharmacyManager = userPharmacyManager;
            _authManager = authManager;
            _repository = repository;
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
            var pharmacy = await _userPharmacyManager.FindByNameAsync(user.UserName!);
            return Ok(
            new
            {
                Token = await _authManager.CreateToken(),
                UserId = await _userPharmacyManager.GetUserIdAsync(pharmacy!)
            }
            );
        }
        [HttpGet]
        public async Task<IActionResult> GetPharmacies([FromQuery]PharmacyParamters paramters)
        {
            try
            {
                var pharmacies = await _repository.Pharmacy.GetAllPharmaciesAsync(paramters,trackChanges: false);
                var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);

                return Ok(pharmaciesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetPharmacies)} action {ex}");
                return StatusCode(500, "Internal Server Error!");
            }
        }
        [HttpGet("{pharmacyId}")]
        public async Task<IActionResult> GetPharmacy(string pharmacyId)
        {
            if (pharmacyId.IsNullOrEmpty())
            {
                _logger.LogInfo("Pharmacy ID is null!");
                return BadRequest("Pharmacy ID is null");
            }
            var pharmacy = await _repository.Pharmacy.GetPharmacyByIdAsync(pharmacyId, trackChanges: false);
            if (pharmacy is null)
            {
                _logger.LogInfo($"Pharmacy with id: {pharmacyId} doesn't exist in the database.");
                return NotFound();
            }
            var pharmacyDto = _mapper.Map<PharmacyDto>(pharmacy);
            return Ok(pharmacyDto);
        }
        [HttpDelete("{pharmacyId}")]
        public async Task<IActionResult> DeletePharmacy(string pharmacyId)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyByIdAsync(pharmacyId, trackChanges: false);
            if (pharmacy is null)
            {
                _logger.LogInfo($"Pharmacy with id: {pharmacyId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Pharmacy.DeletePharmacy(pharmacy);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpPost("Product")]
        public async Task<IActionResult> CreateProductsToPharmacy(string pharmacyId,
            [FromBody] List<ProductForCreateDto> products)
        {
            if (products is null)
            {
                _logger.LogError("ProductForCreateDto object sent from client is null ");
                return BadRequest("ProductforCreateDto object is null!");
            }
            var productsEntity = _mapper.Map<IEnumerable<Product>>(products).ToList();
            _repository.Product.AddProductsToPharmacy(pharmacyId, productsEntity);
            await _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("Product")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParamters paramters)
        {
            try
            {
                var products = await _repository.Product.GetAllProductsAsync(paramters,trackChanges: false);
                var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went Wrong in the {nameof(GetAllProducts)} Action: {ex}");
                return StatusCode(500, "Internal Server Error!");
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            if ( productId is 0)
            {
                _logger.LogInfo("Product ID is null!");
                return BadRequest("Product ID is null");
            }
            var product = await _repository.Product.GetProductByIdAsync(productId, trackChanges: false);
            if (product is null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpDelete("Product")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (productId is 0)
            {
                _logger.LogInfo("Product ID is null!");
                return BadRequest("Product ID is null");
            }
            var product = await _repository.Product.GetProductByIdAsync(productId, trackChanges: false);
            if (product is null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Product.DeleteProduct(product);
            await _repository.SaveChanges();
            return NoContent();
        }

        [HttpGet("pharmacyId")]
        public async Task<IActionResult> GetPharmacyProducts(string pharmacyId)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyByIdAsync(pharmacyId, trackChanges: false);
            if (pharmacy is null)
            {
                _logger.LogInfo($"Pharmacy with id: {pharmacyId} doesn't exist in the database.");
                return NotFound();
            }
            var productsFromDb = await _repository.Product.GetPharmacyProducts(pharmacyId);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            return Ok(productsFromDb);
        }
        [HttpGet("OrderForPatient")]
        public async Task<IActionResult> GetOrdersForPatient(string patientId)
        {
            if (patientId is null)
            {
                _logger.LogError("patientId is null!");
                return BadRequest("patientId is null");
            }
            var patient = await _repository.Patient.GetPatientByIdAsync(patientId);
            if(patient is null)
            {
                _logger.LogInfo($"Patient with id : {patientId} doesn't exist in database");
                return NotFound($"Patient with id : {patientId} doesn't exist in database");
            }
            var orders = await _repository.Order.GetOrdersForPatientAsync(patientId);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);

        }
        [HttpGet("OrderForPharmacy")]
        public async Task<IActionResult> GetOrdersForPharmacy(string pharmacyId)
        {
            if (pharmacyId is null)
            {
                _logger.LogError("pharmacyId is null!");
                return BadRequest("pharmacyId is null");
            }
            var pharmacy =await _repository.Pharmacy.GetPharmacyByIdAsync(pharmacyId,false);
            if(pharmacy is null)
            {
                _logger.LogInfo($"pharmacy with id : {pharmacyId} doesn't exist in database");
                return NotFound($"pharmacy with id : {pharmacyId} doesn't exist in database");
            }
            var orders =await _repository.Order.GetOrdersForPharmacyAsync(pharmacyId);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);

        }
        [HttpPost("Order")]
        public async Task<IActionResult> PostOrder([FromBody] OrderForCreateDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo($"Error in validation of model State {ModelState}");
                return BadRequest(ModelState);
            }
            var order = _mapper.Map<Order>(orderDto);
            _repository.Order.CreateOrder(order);
           await _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("Order")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            if (orderId is 0)
            {
                _logger.LogInfo("orderIdis null!");
                return BadRequest("orderId is null");
            }
            var order = await _repository.Order.GetOrderAsync(orderId);
            if (order is null)
            {
                _logger.LogInfo($"order with id: {orderId} doesn't exist in the database.");
                return NotFound();
            }
            var orderDto=_mapper.Map<OrderDto>(order); 
            return Ok(orderDto);
        }
    }
}
