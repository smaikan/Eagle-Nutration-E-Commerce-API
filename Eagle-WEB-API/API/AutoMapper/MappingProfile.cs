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
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderCreateDTO, Order>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        CreateMap<OrderDetailCreateDTO, OrderDetail>().ReverseMap();
        CreateMap<User, UserDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserEmail));
        CreateMap<UserCreateDTO, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        CreateMap<UserLoginDTO, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        CreateMap<Comment, CommentDTO>().ReverseMap();
        CreateMap<CommentCreateDTO, Comment>().ReverseMap();
        
    }
}
