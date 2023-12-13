using ProductManagementService.Common.Generics;
using UserService.Model.DTO;

namespace UserService.Service.Interface
{
    public interface ISellerService
    {
        Task<Result<long>> CreateAccountAsync(SellerDTO sellerDTO);
        Task<Result<string>> LogInAsync(CustomerLoginDTO customerLoginDTO);
    }
}
