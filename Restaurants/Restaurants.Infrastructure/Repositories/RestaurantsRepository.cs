using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantDbContext dbContext) : IRestaurantsRepository
    {
        public async Task<int> Create(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task<Restaurant> Create2(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            await dbContext.SaveChangesAsync();

            var newRestaurant = await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == restaurant.Id);

            return newRestaurant;
        }

        public async Task Delete(Restaurant restaurant)
        {
            dbContext.Restaurants.Remove(restaurant);
            await dbContext.SaveChangesAsync();
        }

        //public readonly RestaurantDbContext _dbContext;
        //public RestaurantsRepository(RestaurantDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants
                .Include(r=>r.Dishes)
                .ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetById(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Include (r=>r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);
            return restaurant;
        }
    }
}
