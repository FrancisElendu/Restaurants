using AutoMapper;
using BuildingBlock.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    //public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) 
        //: IRequestHandler<CreateRestaurantCommand, int>

    //public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) 
        //: ICommandHandler<CreateRestaurantCommand, int>
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) 
        : ICommandHandler<CreateRestaurantCommand, RestaurantDto>
    {
        //public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        //{
        //    logger.LogInformation("Creating a new restaurant");

        //    var restaurant = mapper.Map<Restaurant>(request);

        //    var id = await restaurantsRepository.Create(restaurant);
        //    return id;
        //}

        public async Task<RestaurantDto?> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new restaurant");

            var restaurant = mapper.Map<Restaurant>(request);

            var newRestaurant = await restaurantsRepository.Create2(restaurant);

            var restaurantDto = mapper.Map<RestaurantDto>(newRestaurant);
            return restaurantDto;
        }
    }
}
