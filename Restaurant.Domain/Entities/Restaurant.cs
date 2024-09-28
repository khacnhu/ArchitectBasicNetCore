using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class ResTauRant
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category {get;set; } = default!;
        public bool HasDelivery { get; set; }
        
        public string? ContactEmail { get;set; }
        public string? ContactName { get; set; }

        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new();

    }
}
