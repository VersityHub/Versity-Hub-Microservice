using UserService.Model.Customer;

namespace UserService.Repository.Interface
{
    public interface IJwtRepository
    {
        Task<string> GenerateJwtToken(CustomerLogin customerLogin);
    }
}
