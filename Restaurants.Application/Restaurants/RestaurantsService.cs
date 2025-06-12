using Restaurants.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
namespace Restaurants.Application.Restaurants;

public class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger):IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantRepository.GetAllAsync();
        return restaurants;
    }
}
