using System;

namespace Domain
{
    public class BaseAudit
    {
        public DateTime CreatedAt { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AppUser UpdatedBy { get; set; }
    }
}