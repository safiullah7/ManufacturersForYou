using System;
using System.Collections.Generic;

namespace Domain
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        // add imageurl column
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}