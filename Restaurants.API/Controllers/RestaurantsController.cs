using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }
    }
