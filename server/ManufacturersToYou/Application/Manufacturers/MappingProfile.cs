using Application.Products;
using AutoMapper;
using Domain;

namespace Application.Manufacturers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Product, ManufacturersProductDto>();
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.DisplayName));
        }
    }
}