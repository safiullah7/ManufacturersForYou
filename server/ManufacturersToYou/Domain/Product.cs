using System;
using System.Collections.Generic;

namespace Domain
{
    public class Product : BaseAudit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        
        // public string Category { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments {get; set;}
    }
}