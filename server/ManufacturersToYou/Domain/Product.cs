using System;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public string Features { get; set; }
        public string Category { get; set; } // needs separate table as well
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ImageUrl { get; set; }
        // public string Photos { get; set; } 
        // public string ManufacturerId { get; set; } 
        // public string Comments { get; set; } 
    }
}