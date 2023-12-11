using ProductManagementService.Common.Generics;
using ProductManagementService.Model.Products;

namespace ProductManagementService.Service.ProductsService.Interface
{
    public interface IProductService
    {
        Task<Result<long>> CreateProduct(ProductDTO product);
        Task<Result<List<Product>>> GetProducts();
        Task<Result<Product>> GetProduct(long productId);
        Task<Result<bool>> RemoveProduct(long productId);
        Task<Result<bool>> UpdateProduct(long productId, ProductDTO product);
    }
}