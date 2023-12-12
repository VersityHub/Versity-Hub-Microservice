using AutoMapper;
using ProductManagementService.Model.ProductCategories;
using ProductManagementService.Model.Products;

namespace ProductManagementService.Helpers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Product, ProductDTO>()
            .ReverseMap();
        CreateMap<Category, CategoryDTO>()
            .ReverseMap();
    }
}
