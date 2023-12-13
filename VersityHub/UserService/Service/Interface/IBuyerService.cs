using ProductManagementService.Common.Generics;
using UserService.Model.DTO;

namespace UserService.Service.Interface
{
    public interface IBuyerService
    {
        Task<Result<long>> CreateAccountAsync(BuyerDTO buyerDTO);
        Task<Result<string>> LogInAsync(CustomerLoginDTO customerLoginDTO);
    }
}
