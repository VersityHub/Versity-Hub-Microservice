using Microsoft.AspNetCore.Identity;
using UserService.Model.Customer;
using UserService.Repository.Interface;

namespace UserService.Repository
{
    public class SellerRepository: ISellerRepository
    {
        private readonly UserManager<ApplicationCustomer> _userManager;
        private readonly SignInManager<ApplicationCustomer> _signInManager;
        private readonly IJwtRepository _jwtRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SellerRepository> _logger;
        public SellerRepository(UserManager<ApplicationCustomer> userManager,
            SignInManager<ApplicationCustomer> signInManager,
            IJwtRepository jwtRepository,
            IConfiguration configuration,
            ILogger<SellerRepository> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtRepository = jwtRepository;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<IdentityResult> CreateAccountAsync(ApplicationCustomer createSellerAccount)
        {
            createSellerAccount.UserName = createSellerAccount.Email;
            createSellerAccount.PhoneNumber = createSellerAccount.Number;
            await _userManager.CreateAsync(createSellerAccount, createSellerAccount.Password);
            return await _userManager.AddToRoleAsync(createSellerAccount, "Seller");

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
