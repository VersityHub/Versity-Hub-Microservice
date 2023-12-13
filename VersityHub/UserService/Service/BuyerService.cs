using AutoMapper;
using ProductManagementService.Common.Generics;
using UserService.Data;
using UserService.Model.Customer;
using UserService.Model.DTO;
using UserService.Repository.Interface;
using UserService.Service.Interface;

namespace UserService.Service
{
    public class BuyerService : IBuyerService
    {
        
        private readonly IBuyerRepository _buyerRepository;
        private readonly ILogger<BuyerService> _logger;
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        public BuyerService(
            IBuyerRepository buyerRepository,
            ILogger<BuyerService> logger, 
            UserDbContext context,
            IMapper mapper)
        {
            _buyerRepository = buyerRepository;
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<long>> CreateAccountAsync(BuyerDTO buyerDTO)
        {
            Result<long> result = new(false);

            try
            {
                var account = _mapper.Map<ApplicationCustomer>(buyerDTO);

                var response = await _buyerRepository.CreateAccountAsync(account);

                await _context.SaveChangesAsync();


                if (response.Succeeded)
                {
                    result.SetSuccess("Account Created Successfully");
                    result.SetError("Product not created", "Product not created");
                }
                else
                {
                    result.SetError("Email already has an account created", "Try a different email");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Account");
                result.SetError(ex.ToString(), "Error while creating Account");
            }
            return result;
        }

        public async Task<Result<string>> LogInAsync(CustomerLoginDTO customerLoginDTO)
        {
            Result<string> result = new(false);

            var login = _mapper.Map<CustomerLogin>(customerLoginDTO);
            var response = await _buyerRepository.LogInAsync(login);

            if (string.IsNullOrEmpty(response))
            {
                result.SetError("Product not created", "Product not created");
            }
            else
            {
                result.SetSuccess("Try a different email");
            }
            return result;
        }
    }
}
