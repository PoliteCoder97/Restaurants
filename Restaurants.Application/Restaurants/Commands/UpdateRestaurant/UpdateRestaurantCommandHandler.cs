using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Repositories;
using Restaurants.Entities;

namespace DefaultNamespace;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository
) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new restaurant.");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            return false;
        }
        var restaurantMapper = mapper.Map<Restaurant>(request);

        restaurant.Name = restaurantMapper.Name;
        restaurant.Description = restaurantMapper.Description;
        restaurant.Address = restaurantMapper.Address;
        restaurant.Category = restaurantMapper.Category;
        restaurant.ContactEmail = restaurantMapper.ContactEmail;
        restaurant.ContactNumber = restaurantMapper.ContactNumber;
        restaurant.HasDelivery = restaurantMapper.HasDelivery;

        var id = await restaurantRepository.Update(restaurant);
        return id;
    }
}