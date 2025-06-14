using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Entities;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(
    ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository
) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new restaurant. {@restaurant}", request);
        var restaurant = mapper.Map<Restaurant>(request);
        var id = await restaurantRepository.Create(restaurant);
        return id;
    }
}