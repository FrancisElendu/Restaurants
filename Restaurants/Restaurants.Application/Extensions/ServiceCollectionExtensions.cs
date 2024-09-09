using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dtos;
using Restaurants.Application.Mapper;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantsService, RestaurantsService>();
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<ResponseDto>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}
