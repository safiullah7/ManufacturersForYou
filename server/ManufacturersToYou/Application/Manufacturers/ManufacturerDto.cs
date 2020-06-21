using System;
using System.Collections.Generic;
using Application.Products;

namespace Application.Manufacturers
{
    public class ManufacturerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public int ProductsCount { get; set; }
        public ICollection<ManufacturersProductDto> Products { get; set; }
    }
}