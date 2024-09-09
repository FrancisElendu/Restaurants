using AutoMapper;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Map from Dish to DishDto
                config.CreateMap<Dish, DishDto>();  //.ReverseMap();

                // Map from Address to AddressDto
                config.CreateMap<Address, AddressDto>().ReverseMap();

                //config.CreateMap<CreateRestaurantDto, Restaurant>()
                //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

                config.CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
                //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                // {
                //     City = src.Address.City,
                //     Street = src.Address.Street,
                //     ZipCode = src.Address.ZipCode
                // }));

                // Map from Restaurant to RestaurantDto
                config.CreateMap<Restaurant, RestaurantDto>()
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

               
            });
            return mappingConfig;
        }
    }
}
