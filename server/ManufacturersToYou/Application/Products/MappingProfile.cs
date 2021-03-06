using System.Collections.Generic;
using Application.Manufacturers;
using AutoMapper;
using Domain;

namespace Application.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.Command, Product>();

            CreateMap<Product, ProductDto>();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author.DisplayName));
        }
    }
}