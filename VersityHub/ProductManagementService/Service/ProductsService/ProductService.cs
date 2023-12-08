using AutoMapper;
using ProductManagementService.Common.Generics;
using ProductManagementService.Data;
using ProductManagementService.Model.Products;
using ProductManagementService.Repository.ProductsRepository.Interface;
using ProductManagementService.Service.ProductsService.Interface;

namespace ProductManagementService.Service.ProductsService;
public partial class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;
    private readonly IConfiguration _config;
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        ILogger<ProductService> logger, IConfiguration config,
        ProductDbContext context,
        IMapper mapper
        )
    {
        _productRepository = productRepository;
        _logger = logger;
        _config = config;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<long>> CreateProduct(ProductDTO productDTO)
    {
        Result<long> result = new(false);

        try
        {
            var product = _mapper.Map<Product>(productDTO);

            var response = await _productRepository.CreateProduct(product);

            await _context.SaveChangesAsync();


            result.Content = response.ProductId;
            if (response == null)
            {
                result.SetError("Product not created", "Product not created");
            }
            else
            {
                result.SetSuccess(response.ProductId, $"Product with Id {response.ProductId} Created Successfully !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating Product");
            result.SetError(ex.ToString(), "Error while creating Product");
        }
        return result;
    }

    public async Task<Result<List<Product>>> GetProducts()
    {
        Result<List<Product>> result = new(false);

        try
        {
            var response = await _productRepository.GetProducts();

            result.SetSuccess(response.ToList(), "Retrieved Successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while retrieving Products");
            result.SetError(ex.ToString(), "Error while retrieving Products");
        }
        return result;
    }

    public async Task<Result<Product>> GetProduct(long productId)
    {
        Result<Product> result = new(false);

        try
        {
            var response = await _productRepository.GetProduct(productId);

            result.SetSuccess(response, "Retrieved Successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while retrieving Product");
            result.SetError(ex.ToString(), "Error while retrieving Product");
        }

        return result;
    }

    public async Task<Result<bool>> RemoveProduct(long productId)
    {
        Result<bool> result = new(false);

        try
        {
            var response = await _productRepository.RemoveProduct(productId);
            result.Content = response;
            await _context.SaveChangesAsync();

            if (!response)
            {
                result.SetError("Product not deleted", $"Product with Id {productId} not deleted");
            }
            else
            {
                result.SetSuccess(response, $"Product with Id {productId} deleted Successfully !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while removing Product");
            result.SetError(ex.ToString(), "Error while removing Product");
        }

        return result;
    }

    public async Task<Result<bool>> UpdateProduct(long productId, ProductDTO productDTO)
    {
        Result<bool> result = new(false);

        try
        {
            var existingProduct = await _productRepository.GetProduct(productId);

            if (existingProduct == null) result.SetError("Product not updated", $"Product with Id {productId} not updated");

            _mapper.Map(productDTO, existingProduct);

            var response = await _productRepository.UpdateProduct(productId, existingProduct);

            await _context.SaveChangesAsync();

            if (!response)
            {
                result.SetError("Product not updated", $"Product with Id {productId} not updated");
            }
            else
            {
                result.SetSuccess(response, $"Product with Id {productId} updated Successfully.");
            }

            result.Content = response;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while Updating Product");
            result.SetError(ex.ToString(), "Error while Updating Product");
        }
        return result;
    }
}