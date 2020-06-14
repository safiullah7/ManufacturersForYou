using System.Collections.Generic;

namespace Domain
{
    public class AppUser
    {
        public string DisplayName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}