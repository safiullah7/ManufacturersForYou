using System;

namespace Application.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public string Features { get; set; }
        public string Category { get; set; } // needs separate table as well
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}