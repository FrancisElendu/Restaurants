using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetById(int Id);
        Task<int> Create(Restaurant restaurant);
        Task<Restaurant> Create2(Restaurant restaurant);
        Task Delete(Restaurant restaurant);
    }
}
