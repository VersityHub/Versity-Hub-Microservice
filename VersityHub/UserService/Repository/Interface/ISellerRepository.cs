using Microsoft.AspNetCore.Identity;
using UserService.Model.Customer;

namespace UserService.Repository.Interface
{
    public interface ISellerRepository
    {
        Task<IdentityResult> CreateAccountAsync(ApplicationCustomer createSellerAccount);
        Task<string> LogInAsync(CustomerLogin customerLogin);
    }
}
