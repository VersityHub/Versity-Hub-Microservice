using AutoMapper;
using ProductManagementService.Common.Generics;
using ProductManagementService.Data;
using ProductManagementService.Model.ProductCategories;
using ProductManagementService.Repository.CategoryRepository.Interface;
using ProductManagementService.Service.CategoryService.Interface;

namespace ProductManagementService.Service.CategoryService;
public partial class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CategoryService> _logger;
    private readonly IConfiguration _config;
    private readonly PMDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> logger, IConfiguration config,
        PMDbContext context,
        IMapper mapper
        )
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
        _config = config;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<long>> CreateCategory(CategoryDTO categoryDTO)
    {
        Result<long> result = new(false);

        try
        {
            var category = _mapper.Map<Category>(categoryDTO);

            var response = await _categoryRepository.CreateCategory(category);

            await _context.SaveChangesAsync();


            result.Content = response.CategoryId;
            if (response == null)
            {
                result.SetError("Category not created", "Category not created");
            }
            else
            {
                result.SetSuccess(response.CategoryId, $"Category with Id {response.CategoryId} Created Successfully !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating Category");
            result.SetError(ex.ToString(), "Error while creating Category");
        }
        return result;
    }

    public async Task<Result<List<Category>>> GetCategories()
    {
        Result<List<Category>> result = new(false);

        try
        {
            var response = await _categoryRepository.GetCategories();

            result.SetSuccess(response.ToList(), "Retrieved Successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while retrieving Categories");
            result.SetError(ex.ToString(), "Error while retrieving Categories");
        }
        return result;
    }

    public async Task<Result<Category>> GetCategory(long categoryId)
    {
        Result<Category> result = new(false);

        try
        {
            var response = await _categoryRepository.GetCategory(categoryId);

            result.SetSuccess(response, "Retrieved Successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while retrieving Category");
            result.SetError(ex.ToString(), "Error while retrieving Category");
        }

        return result;
    }

    public async Task<Result<bool>> RemoveCategory(long categoryId)
    {
        Result<bool> result = new(false);

        try
        {
            var response = await _categoryRepository.RemoveCategory(categoryId);
            result.Content = response;
            await _context.SaveChangesAsync();

            if (!response)
            {
                result.SetError("Category not deleted", $"Category with Id {categoryId} not deleted");
            }
            else
            {
                result.SetSuccess(response, $"Category with Id {categoryId} deleted Successfully !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while removing Category");
            result.SetError(ex.ToString(), "Error while removing Category");
        }

        return result;
    }

    public async Task<Result<bool>> UpdateCategory(long categoryId, CategoryDTO categoryDTO)
    {
        Result<bool> result = new(false);

        try
        {
            var existingCategory = await _categoryRepository.GetCategory(categoryId);

            if (existingCategory == null) result.SetError("Category not updated", $"Category with Id {categoryId} not updated");

            _mapper.Map(categoryDTO, existingCategory);

            var response = await _categoryRepository.UpdateCategory(categoryId, existingCategory);

            await _context.SaveChangesAsync();

            if (!response)
            {
                result.SetError("Category not updated", $"Category with Id {categoryId} not updated");
            }
            else
            {
                result.SetSuccess(response, $"Category with Id {categoryId} updated Successfully.");
            }

            result.Content = response;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while Updating Category");
            result.SetError(ex.ToString(), "Error while Updating Category");
        }
        return result;
    }
}