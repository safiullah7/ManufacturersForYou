using System;
using System.Collections.Generic;
using Application.Features;
using Application.Manufacturers;
using Domain;

namespace Application.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<FeatureDto> Features { get; set; }
        public ICollection<CommentDto> Comments {get; set;}
    }
}