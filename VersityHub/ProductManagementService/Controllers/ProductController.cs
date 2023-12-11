using Microsoft.AspNetCore.Mvc;
using ProductManagementService.Common.Generics;
using ProductManagementService.Model.Products;
using ProductManagementService.Service.ProductsService.Interface;

namespace ProductManagementService.Controllers;

public partial class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = new Result<List<Product>>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _productService.GetProducts();
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProduct(long id)
    {
        var result = new Result<Product>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _productService.GetProduct(id);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        var result = new Result<long>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _productService.CreateProduct(productDTO);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProduct(long id, [FromBody] ProductDTO productDTO)
    {
        var result = new Result<bool>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _productService.UpdateProduct(id, productDTO);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveProduct(long id)
    {
        var result = new Result<bool>();
        result.RequestTime = DateTime.UtcNow;

        var response = await _productService.RemoveProduct(id);
        result = response;
        result.ResponseTime = DateTime.UtcNow;
        return Ok(result);
    }
}
