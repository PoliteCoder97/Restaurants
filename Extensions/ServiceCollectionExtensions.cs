using Microsoft.EntityFrameworkCore;
using Restaurants.Persistance;
using Restaurants.Seeders;

namespace Restaurants.Extensions;

public static class ServiceCollectionExtensions
{
  public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    // if (string.IsNullOrEmpty(connectionString))
    // {
    //   throw new InvalidOperationException("Connection string 'RestaurantsDb' is not configured.");
    // }

    Console.WriteLine($"Using connection string: {connectionString}");

    services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString));

    services.AddScoped<IRestuarantSeeder, RestuarantSeeder>();
  }
}
