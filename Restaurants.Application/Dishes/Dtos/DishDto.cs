using System;
using Restaurants.Entities;

namespace Restaurants.Application.Dishes.Dtos;

public class DishDto
{
  public int Id { get; set; }
  public int RestuarantId { get; set; }
  public string Name { get; set; } = default!;
  public string Description { get; set; } = default!;
  public decimal Price { get; set; }
}
