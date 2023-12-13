using AutoMapper;
using UserService.Model.Customer;
using UserService.Model.DTO;

namespace UserService.Helpers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<ApplicationCustomer, BuyerDTO>()
            .ReverseMap();
        CreateMap<ApplicationCustomer, SellerDTO>()
            .ReverseMap();
        CreateMap<CustomerLogin, CustomerLoginDTO>()
            .ReverseMap();
    }
}
