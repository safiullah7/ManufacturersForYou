using System;

namespace Domain
{
    public class BaseAudit
    {
        public DateTime CreatedAt { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual AppUser UpdatedBy { get; set; }
    }
}