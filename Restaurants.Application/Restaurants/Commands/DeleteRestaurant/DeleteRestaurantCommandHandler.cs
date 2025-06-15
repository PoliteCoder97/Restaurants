using MediatR;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DefaultNamespace;

public class DeleteRestaurantCommandHandler(
    ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository
) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with ID: {requestId}" , request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            return false;
        }

        await restaurantRepository.Delete(restaurant);
        return true;
    }
}