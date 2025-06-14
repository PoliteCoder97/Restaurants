using Microsoft.Extensions.Logging;
using Restaurants.Entities;
using Restaurants.Persistance;

namespace Restaurants.Seeders;

internal class RestuarantSeeder(RestaurantsDbContext dbContext, ILogger<RestuarantSeeder> logger) : IRestuarantSeeder
{

    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {

            logger.LogInformation("Connected to database.");

            if (!dbContext.Restaurants.Any())
            {
                logger.LogInformation("Seeding restaurant data...");

                var resturants = GetRestaurants();
                dbContext.Restaurants.AddRange(resturants);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Seeding completed.");
            }
            else
            {
                logger.LogInformation("Restaurants already exist. Skipping seeding.");
            }
        }
        else
        {
            logger.LogWarning("Cannot connect to the database.");
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        return new List<Restaurant>
        {
            new Restaurant
            {
                Name = "Pizza Place",
                Description = "The best pizza in town",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "politecoder@gmail.com",
                Address = new Address
                {
                    Street = "123 Pizza St",
                    City = "Pizzaville",
                    PostalCode = "12345"
                },
                Dishes = new List<Dish>
                {
                    new Dish
                    {
                        Name = "Margherita Pizza",
                        Description = "Classic pizza with fresh tomatoes and basil",
                        Price = 9.99m
                    },
                    new Dish
                    {
                        Name = "Pepperoni Pizza",
                        Description = "Spicy pepperoni with mozzarella cheese",
                        Price = 11.99m
                    }
                }
            },
            new Restaurant
            {
                Name = "Burger Joint",
                Description = "Delicious burgers and fries",
                Category = "American",
                HasDelivery = true,
                ContactEmail = "politecoder@gmail.com",
                Address = new Address
                {
                    Street = "456 Burger Blvd",
                    City = "Burger City",
                    PostalCode = "67890"
                },
                ContactNumber = "123-456-7890",
                Dishes = new List<Dish>
                {
                    new Dish
                    {
                        Name = "Cheeseburger",
                        Description = "Juicy beef patty with cheese, lettuce, and tomato",
                        Price = 8.99m
                    },
                    new Dish
                    {
                        Name = "Fries",
                        Description = "Crispy golden fries",
                        Price = 3.99m
                    }
                }
            }
        };
    }
}
