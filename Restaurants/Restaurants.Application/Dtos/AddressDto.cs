using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dtos
{
    public class AddressDto
    {
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        //public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
    }
}
