namespace ProductManagementService.Model.ProductCategories
{
    public class CategoryDTO
    {

        public long CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool isActive { get; set; }
    }
}
