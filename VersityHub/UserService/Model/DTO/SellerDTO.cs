using System.ComponentModel.DataAnnotations;

namespace UserService.Model.DTO
{
    public class SellerDTO
    {
        public long CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\+234\d{10}$", ErrorMessage = "Invalid Phone Number format. It should start with +234 and have 10 additional digits.")]
        public string Number { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string UniversityID { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid Date of Birth format")]
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
