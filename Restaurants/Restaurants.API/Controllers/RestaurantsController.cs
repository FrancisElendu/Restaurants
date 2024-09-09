using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    //public class RestaurantsController(IRestaurantsService restaurantsService, ResponseDto responseDto) : ControllerBase
    public class RestaurantsController(IMediator mediator, ResponseDto responseDto) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //var restaurants = await restaurantsService.GetAllRestaurants();
                var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
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
            //var restaurant = await restaurantsService.GetById(id);
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
                return NotFound();
            //return Ok(restaurant);

            responseDto.Result = restaurant;
            return Ok(responseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            try
            {
                //var id = await restaurantsService.Create(createRestaurantDto);
                var id = await mediator.Send(command);
                responseDto.Result = id;
                responseDto.IsSuccess = true; // Indicate that the operation was successful
                return CreatedAtAction(nameof(GetById), new { id = id }, responseDto); // Return responseDto in the CreatedAtAction method
                //return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (Exception ex)
            {

                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
                return BadRequest(responseDto); // Return BadRequest with responseDto in case of an error
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            try
            {
                ////var restaurant = await restaurantsService.GetById(id);
                ////return Ok(restaurant);
                var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));

                if (isDeleted)
                {
                    responseDto.Result = null;
                    responseDto.IsSuccess = true;
                    responseDto.Message = "Restaurant deleted successfully.";
                    return StatusCode(204, responseDto); // Return a 204 status with the responseDto as the body
                }
                else
                {
                    responseDto.Result = null;
                    responseDto.IsSuccess = false;
                    responseDto.Message = "Restaurant not found or could not be deleted.";
                    return StatusCode(404, responseDto); // Return a 404 status with the responseDto as the body
                }
            }
            catch (Exception ex)
            {

                responseDto.Result = null;
                responseDto.IsSuccess = false;
                responseDto.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, responseDto); // Return a 500 status with the responseDto as the body

            }

            //return StatusCode(204, responseDto); // Return a 204 status with the responseDto as the body


        }
    }
}
