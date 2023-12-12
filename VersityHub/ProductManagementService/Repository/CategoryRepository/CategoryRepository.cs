using Microsoft.EntityFrameworkCore;
using ProductManagementService.Data;
using ProductManagementService.Model.ProductCategories;
using ProductManagementService.Repository.CategoryRepository.Interface;

namespace ProductManagementService.Repository.CategoryRepository;
public partial class CategoryRepository : ICategoryRepository
{

    private readonly PMDbContext _context;
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(PMDbContext context, ILogger<CategoryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Category> CreateCategory(Category category)
    {

        await _context.Categories.AddAsync(category);
        return category;

    }

    public async Task<List<Category>> GetCategories()
    {
        var results = await _context.Categories.ToListAsync();

        return results;

    }

    public async Task<Category> GetCategory(long categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);

        return category;
    }

    public async Task<bool> RemoveCategory(long categoryId)
    {
        try
        {
            var category = await _context.Categories
                        .Where(x => x.CategoryId == categoryId)
                        .FirstAsync();

            var result = _context.Categories.Remove(category);

            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> UpdateCategory(long id, Category category)
    {
        try
        {
            _context.Categories.Update(category);

            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
