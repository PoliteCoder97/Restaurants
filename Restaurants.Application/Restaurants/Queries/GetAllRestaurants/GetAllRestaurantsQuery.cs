using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Entities;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{

}