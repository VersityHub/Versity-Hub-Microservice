using Microsoft.AspNetCore.Identity;
using UserService.Model.Customer;

namespace UserService.Repository.Interface
{
    public interface IBuyerRepository
    {
        Task<IdentityResult> CreateAccountAsync(ApplicationCustomer createBuyerAccount);
        Task<string> LogInAsync(CustomerLogin customerLogin);
    }
}
