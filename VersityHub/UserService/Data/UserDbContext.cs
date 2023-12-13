using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Model.Customer;

namespace UserService.Data
{
    public class UserDbContext: IdentityDbContext<ApplicationCustomer>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {
            
        }
    }
}
