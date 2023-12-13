using AutoMapper;
using ProductManagementService.Common.Generics;
using UserService.Data;
using UserService.Model.Customer;
using UserService.Model.DTO;
using UserService.Repository.Interface;
using UserService.Service.Interface;

namespace UserService.Service
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ILogger<SellerService> _logger;
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        public SellerService(
            ISellerRepository sellerRepository,
            ILogger<SellerService> logger, 
            UserDbContext context,
            IMapper mapper)
        {
           
            _sellerRepository = sellerRepository;
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<long>> CreateAccountAsync(SellerDTO sellerDTO)
        {
            Result<long> result = new(false);

            try
            {
                var account = _mapper.Map<ApplicationCustomer>(sellerDTO);

                var response = await _sellerRepository.CreateAccountAsync(account);

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
            var response = await _sellerRepository.LogInAsync(login);

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
