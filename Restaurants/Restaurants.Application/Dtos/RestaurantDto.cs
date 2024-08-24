using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        //public string City { get; set; } = default!;
        //public string Street { get; set; } = default!;
        //public string ZipCode { get; set; } = default!;
        //public string? ContactEmail { get; set; }
        //public string? ContactPhone { get; set; }
        public AddressDto? Address { get; set; }
        public List<DishDto> Dishes { get; set; } = new();
        
    }
}
