using Microsoft.AspNetCore.Mvc;
using ProductManagementService.Common.Generics;
using ProductManagementService.Model.ProductCategories;
using ProductManagementService.Service.CategoryService.Interface;

namespace ProductManagementService.Controllers;

public partial class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var result = new Result<List<Category>>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _categoryService.GetCategories();
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategory(long id)
    {
        var result = new Result<Category>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _categoryService.GetCategory(id);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
    {
        var result = new Result<long>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _categoryService.CreateCategory(categoryDTO);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory(long id, [FromBody] CategoryDTO categoryDTO)
    {
        var result = new Result<bool>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _categoryService.UpdateCategory(id, categoryDTO);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveCategory(long id)
    {
        var result = new Result<bool>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _categoryService.RemoveCategory(id);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }
}
