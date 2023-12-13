using System.ComponentModel.DataAnnotations;

namespace UserService.Model.DTO
{
    public class BuyerDTO
    {
        public long BuyerIdId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Number { get; set; }

        public string Gender { get; set; }

        public string University { get; set; }

        public string UniversityID { get; set; }

        public string Password { get; set; }
    }
}
