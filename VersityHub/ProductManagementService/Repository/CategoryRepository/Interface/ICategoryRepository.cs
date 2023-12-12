using ProductManagementService.Model.ProductCategories;

namespace ProductManagementService.Repository.CategoryRepository.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(long categoryId);
        Task<bool> RemoveCategory(long categoryId);
        Task<bool> UpdateCategory(long id, Category category);
    }
}