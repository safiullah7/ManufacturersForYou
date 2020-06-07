using System.Collections.Generic;
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
        }
    }
}