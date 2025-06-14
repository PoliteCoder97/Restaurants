using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Repositories;
using Restaurants.Entities;
using Restaurants.Persistance;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(x => x.Id == id);

        return restaurant;
    }

    public async Task<int> Create(Restaurant restaurant)
    {
        dbContext.Restaurants.Add(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }
}