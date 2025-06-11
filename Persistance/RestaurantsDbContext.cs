using Microsoft.EntityFrameworkCore;
using Restaurants.Entities;

namespace Restaurants.Persistance;

//dotnet ef database update --verbose --project Restaurants.Infrastructure   --startup-project Restaurants.API
public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      
      modelBuilder.Entity<Restaurant>()
      .OwnsOne(r => r.Address);
      
      modelBuilder.Entity<Restaurant>()
      .HasMany(r => r.Dishes)
      .WithOne()
      .HasForeignKey(d =>d.RestuarantId); 
    }
}
