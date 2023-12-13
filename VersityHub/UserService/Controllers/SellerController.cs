using Microsoft.AspNetCore.Mvc;
using ProductManagementService.Common.Generics;
using UserService.Model.DTO;
using UserService.Service.Interface;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost("createselleraccount")]
        public async Task<IActionResult> CreateAccount([FromBody] SellerDTO sellerDTO)
        {
            var result = new Result<long>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _sellerService.CreateAccountAsync(sellerDTO);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDTO customerLoginDTO)
        {
            var result = new Result<string>();
            result.RequestTime = DateTime.UtcNow;

            var response = await _sellerService.LogInAsync(customerLoginDTO);
            result = response;
            result.ResponseTime = DateTime.UtcNow;
            return Ok(result);
        }
    }
}
