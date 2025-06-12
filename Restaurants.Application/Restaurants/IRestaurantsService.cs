using Restaurants.Entities;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantsService
{
  public Task<IEnumerable<Restaurant>> GetAllRestaurants();
}
