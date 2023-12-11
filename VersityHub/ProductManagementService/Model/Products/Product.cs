using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Model.Products
{
    public class Product
    {
        [Required]
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
