using AutoMapper;
using gRPCwithDotnet.Models;

namespace gRPCwithDotnet.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, CreateProductRequest>()
                .ReverseMap();
            CreateMap<Product, CreateProductResponse>()
                .ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<GetProductResponse, Product>().ReverseMap();
            CreateMap<List<Product>, GetAllProductResponse>().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src));

        }
    }
}
