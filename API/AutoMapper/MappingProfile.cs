using AutoMapper;


using Core.DTOs.CategoryDTOs;
using Core.DTOs.CommentDTOs;
using Core.DTOs.OrderDTOs;
using Core.DTOs.ProductDTOs;
using Core.DTOs.UserDTOs;
using Core.Model;

namespace API.AupoMapper;


public class MappingProfile: Profile
{
    public MappingProfile() 
    {
       
        CreateMap<Product, ProductDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName)).ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription)).ReverseMap();
        CreateMap<Category, CategoryDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName)).ReverseMap();
        CreateMap<ProductCreateDTO, Product>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<ProductUpdateDTO, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<Order, OrderDTO>()
        .ForMember(d => d.TotalPrice,o => o.MapFrom(s => s.OrderDetails.Sum(od => od.TotalPrice))).ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)).ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress)).ReverseMap();
        CreateMap<OrderCreateDTO, Order>()
        .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)).ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
        .ForMember(d => d.TotalPrice,o => o.MapFrom(s => s.OrderDetails.Sum(od => od.TotalPrice))).ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        CreateMap<OrderDetailCreateDTO, OrderDetail>().ReverseMap();
        CreateMap<AddressDTO, ShippingAddress>().ReverseMap();
        CreateMap<User, UserDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserEmail))
        .ForMember(d => d.UserAddress, o => o.MapFrom(s => s.UserAddress));
        CreateMap<UserCreateDTO, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        CreateMap<UpdateDTO, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password)).ForMember(d => d.UserAddress, o => o.MapFrom(s => s.UserAddress)).ReverseMap();
        CreateMap<Address, AddressDTO>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Addressc)).ReverseMap();
        CreateMap<UserLoginDTO, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        CreateMap<Comment, CommentDTO>().ReverseMap();
        CreateMap<CommentCreateDTO, Comment>().ReverseMap();
        
    }
}
