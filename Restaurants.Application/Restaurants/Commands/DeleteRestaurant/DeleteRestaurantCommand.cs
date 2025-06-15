using MediatR;

namespace DefaultNamespace;

public class DeleteRestaurantCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}