using Microsoft.AspNetCore.Mvc;
using ProductManagementService.Common.Generics;
using UserService.Model.DTO;
using UserService.Service.Interface;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpPost("createbuyeraccount")]
        public async Task<IActionResult> CreateAccount([FromBody] BuyerDTO buyerDTO)
        {
            var result = new Result<long>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _buyerService.CreateAccountAsync(buyerDTO);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDTO customerLoginDTO)
        {
            var result = new Result<string>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _buyerService.LogInAsync(customerLoginDTO);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }
    }
}
