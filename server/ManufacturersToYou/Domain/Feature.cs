using System;

namespace Domain
{
    public class Feature
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Product Product { get; set; }
    }
}