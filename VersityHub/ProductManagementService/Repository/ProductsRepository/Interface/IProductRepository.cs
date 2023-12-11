using ProductManagementService.Model.Products;

namespace ProductManagementService.Repository.ProductsRepository.Interface
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(long productId);
        Task<bool> RemoveProduct(long productId);
        Task<bool> UpdateProduct(long id, Product product);
    }
}