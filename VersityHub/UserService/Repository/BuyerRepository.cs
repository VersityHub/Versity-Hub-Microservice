using Microsoft.AspNetCore.Identity;
using UserService.Model.Customer;
using UserService.Repository.Interface;

namespace UserService.Repository
{
    public class BuyerRepository: IBuyerRepository
    {
        private readonly UserManager<ApplicationCustomer> _userManager;
        private readonly SignInManager<ApplicationCustomer> _signInManager;
        private readonly IJwtRepository _jwtRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<BuyerRepository> _logger;
        public BuyerRepository(UserManager<ApplicationCustomer> userManager,
            SignInManager<ApplicationCustomer> signInManager,
            IJwtRepository jwtRepository,
            IConfiguration configuration,
            ILogger<BuyerRepository> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtRepository = jwtRepository;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<IdentityResult> CreateAccountAsync(ApplicationCustomer createBuyerAccount)
        {
            createBuyerAccount.UserName = createBuyerAccount.Email;
            createBuyerAccount.PhoneNumber = createBuyerAccount.Number;
            await _userManager.CreateAsync(createBuyerAccount, createBuyerAccount.Password);
            return await _userManager.AddToRoleAsync(createBuyerAccount, "Buyer");

        }

        public async Task<string> LogInAsync(CustomerLogin customerLogin)
        {

            var result = await _signInManager.PasswordSignInAsync(customerLogin.Email, customerLogin.Password, false, false);
            if (!result.Succeeded)
            {
                _logger.LogInformation($"wrong {customerLogin.Email} or {customerLogin.Password}");
                return ("Incorrect Email or Password");
            }

            return await _jwtRepository.GenerateJwtToken(customerLogin);
        }
    }
}
