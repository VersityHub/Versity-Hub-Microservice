using ProductManagementService.Common.Generics;
using ProductManagementService.Model.ProductCategories;

namespace ProductManagementService.Service.CategoryService.Interface
{
    public interface ICategoryService
    {
        Task<Result<long>> CreateCategory(CategoryDTO category);
        Task<Result<List<Category>>> GetCategories();
        Task<Result<Category>> GetCategory(long categoryId);
        Task<Result<bool>> RemoveCategory(long categoryId);
        Task<Result<bool>> UpdateCategory(long categoryId, CategoryDTO category);
    }
}