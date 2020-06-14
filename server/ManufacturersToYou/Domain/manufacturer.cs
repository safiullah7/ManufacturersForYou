using System;
using System.Collections.Generic;

namespace Domain
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}