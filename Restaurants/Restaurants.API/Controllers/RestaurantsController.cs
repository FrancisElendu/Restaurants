using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService, ResponseDto responseDto) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var restaurants = await restaurantsService.GetAllRestaurants();
                //return Ok(restaurants);
                responseDto.Result = restaurants;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetById(id);
            if(restaurant == null)
                return NotFound();
            //return Ok(restaurant);

            responseDto.Result = restaurant;
            return Ok(responseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            var id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
