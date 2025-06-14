using AutoMapper;
using Restaurants.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService(
    IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsService> logger,
    IMapper mapper
) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantDtosMapped = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantDtosMapped;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation($"Fetching restaurant with ID: {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        if (restaurant == null)
        {
            logger.LogWarning($"Restaurant with ID: {id} not found.");
        }

        return restaurantDto;
    }

    public async Task<int> Create(CreateRestaurantDto restaurantDto)
    {
        logger.LogInformation("Creating a new restaurant.");
        var restaurant = mapper.Map<Restaurant>(restaurantDto);
        var id = await restaurantRepository.Create(restaurant);
        return id;
    }
}