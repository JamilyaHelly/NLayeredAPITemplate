using API.DTOs;
using AutoMapper;
using Core.Models;

namespace API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap< Address,AddressDto>();
            CreateMap<AddressDto,Address>();

            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();

            CreateMap<City,CityDto>();
            CreateMap<CityDto,City>();

            CreateMap<Country,CountryDto>();
            CreateMap<CountryDto,Country>();

            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto,Invoice>();

            CreateMap<Order ,OrderDto>();
            CreateMap<OrderDto,Order>();

            CreateMap<OrderItem,OrderItemDto>();
            CreateMap<OrderItemDto,OrderItem>();

            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto,Product>();

            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();

             CreateMap<Category, CategoryWithProductDto>();
             CreateMap<CategoryWithProductDto,Category>();

             CreateMap<Country ,CountryWithCityDto>();
             CreateMap<CountryWithCityDto,Country>();

             CreateMap<Order,OrderWithOrderItemDto>();
             CreateMap<OrderWithOrderItemDto,Order>();
            
        }
    }
}