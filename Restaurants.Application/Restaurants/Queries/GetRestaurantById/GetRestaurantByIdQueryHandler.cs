using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(
    ILogger<GetRestaurantByIdQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository
    ) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Fetching restaurant with ID: {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        if (restaurant == null)
        {
            logger.LogWarning($"Restaurant with ID: {request.Id} not found.");
        }

        return restaurantDto;
    }
}
