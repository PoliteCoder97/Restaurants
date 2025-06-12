using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Persistance;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Domain.Repositories;
using Restaurants.Seeders;

namespace Restaurants.Extensions;

public static class ServiceCollectionExtensions
{
public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        Console.WriteLine($"Using connection string: {connectionString}");

        services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IRestuarantSeeder, RestuarantSeeder>();
        services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
    }
}
