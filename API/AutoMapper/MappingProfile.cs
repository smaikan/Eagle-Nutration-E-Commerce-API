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
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<ProductCreateDTO, Product>().ReverseMap();
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderCreateDTO, Order>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        CreateMap<OrderDetailCreateDTO, OrderDetail>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserCreateDTO, User>().ReverseMap();
        CreateMap<UserLoginDTO, User>().ReverseMap();
        CreateMap<Comment, CommentDTO>().ReverseMap();
        CreateMap<CommentCreateDTO, Comment>().ReverseMap();
        
    }
}
