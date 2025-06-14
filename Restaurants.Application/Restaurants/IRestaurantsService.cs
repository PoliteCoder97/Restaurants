using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantsService
{
    public Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    public Task<RestaurantDto?> GetRestaurantById(int id);
    public Task<int> Create(CreateRestaurantDto restaurantDto);
}