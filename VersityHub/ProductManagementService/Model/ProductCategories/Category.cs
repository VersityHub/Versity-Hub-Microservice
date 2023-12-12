using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Model.ProductCategories
{
    public class Category
    {
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
