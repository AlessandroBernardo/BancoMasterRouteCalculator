using System;

namespace Domain.Entities
{
    public class Route : BaseEntity
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
    }
}
