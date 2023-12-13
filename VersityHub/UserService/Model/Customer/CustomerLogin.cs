using System.ComponentModel.DataAnnotations;

namespace UserService.Model.Customer
{
    public class CustomerLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
