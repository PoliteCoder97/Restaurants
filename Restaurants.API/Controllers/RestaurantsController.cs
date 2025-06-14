using DefaultNamespace;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

[Route("api/restaurants")]
[ApiController]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(UpdateRestaurantCommand command, [FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (restaurant == null)
        {
            return NotFound();
        }

        command.Id = id; // Ensure the command has the correct ID
        var isUpdated = await mediator.Send(command);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }
}