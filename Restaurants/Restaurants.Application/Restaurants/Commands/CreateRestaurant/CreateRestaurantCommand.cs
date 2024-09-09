using BuildingBlock.CQRS;
using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    //public class CreateRestaurantCommand() : IRequest<int>

    //public class CreateRestaurantCommand() : ICommand<int>
    public class CreateRestaurantCommand() : ICommand<RestaurantDto>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public AddressDto? Address { get; set; }
        //public List<DishDto> Dishes { get; set; } = new();

    }
}
