using Microsoft.EntityFrameworkCore;
using ProductManagementService.Data;
using ProductManagementService.Model.Products;
using ProductManagementService.Repository.ProductsRepository.Interface;

namespace ProductManagementService.Repository.ProductsRepository;
public partial class ProductRepository : IProductRepository
{

    private readonly ProductDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ProductDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Product> CreateProduct(Product product)
    {

        await _context.Products.AddAsync(product);
        return product;

    }

    public async Task<List<Product>> GetProducts()
    {
        var results = await _context.Products.ToListAsync();

        return results;

    }

    public async Task<Product> GetProduct(long productId)
    {
        var product = await _context.Products.FindAsync(productId);

        return product;
    }

    public async Task<bool> RemoveProduct(long productId)
    {
        try
        {
            var product = await _context.Products
                        .Where(x => x.ProductId == productId)
                        .FirstAsync();

            var result = _context.Products.Remove(product);

            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> UpdateProduct(long id, Product product)
    {
        try
        {
            _context.Products.Update(product);

            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
