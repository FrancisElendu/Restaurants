using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting restaurant {request.Id}");
            var restaurant = await restaurantsRepository.GetById(request.Id);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }
    }
}
