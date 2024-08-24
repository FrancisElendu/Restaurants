using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<int> Create(CreateRestaurantDto createRestaurantDto)
        {
            logger.LogInformation("Creating a new restaurant");

            var restaurant = mapper.Map<Restaurant> (createRestaurantDto);
            
            var id = await restaurantsRepository.Create(restaurant);
            return id;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            //var restaurantsDto = restaurants.Select(r => new RestaurantDto()
            //{
            //    Category = r.Category,
            //    Description = r.Description,
            //    Id = r.Id,
            //    HasDelivery = r.HasDelivery,
            //    Address = r.Address == null ? null : new AddressDto
            //    {
            //        Street = r.Address?.Street,
            //        City = r.Address?.City,
            //        ZipCode = r.Address?.ZipCode
            //    },
            //    //Street = r.Address?.Street,
            //    //City = r.Address?.City,
            //    //ZipCode = r.Address.ZipCode,
            //    Dishes = r.Dishes.Select(d => new DishDto()
            //    {
            //        Id = d.Id,
            //        Name = d.Name,
            //        Description = d.Description,
            //        Price = d.Price,
            //        KiloCalories = d.KiloCalories
            //    }).ToList()
            //}).ToList(); 
            return restaurantsDto;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation($"Getting restaurant {id}");
            var restaurant = await restaurantsRepository.GetById(id);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            //var restaurantDto =  new RestaurantDto()
            //{
            //    Category = restaurant.Category,
            //    Description = restaurant.Description,
            //    Id = restaurant.Id,
            //    HasDelivery = restaurant.HasDelivery,
            //    Address = restaurant.Address == null ? null : new AddressDto
            //    {
            //        Street = restaurant.Address.Street,
            //        City = restaurant.Address.City,
            //        ZipCode = restaurant.Address.ZipCode
            //    },
            //    //Street = restaurant.Address?.Street,
            //    //City = restaurant.Address?.City,
            //    //ZipCode = restaurant.Address.ZipCode,
            //    Dishes = restaurant.Dishes.Select(d => new DishDto()
            //    {
            //        Id = d.Id,
            //        Name = d.Name,
            //        Description = d.Description,
            //        Price = d.Price,
            //        KiloCalories = d.KiloCalories
            //    }).ToList()
            //};
            return restaurantDto;

        }
    }
}
